using DomraSinForms.Domen.Models;
using Forms.Mvc.Data;
using Forms.Mvc.Managers;
using Forms.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Controllers;

public class AnswersController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly AnswerManager _manager;
    private readonly ILogger<AnswersController> _logger;

    public AnswersController(ApplicationDbContext context, AnswerManager manager, ILogger<AnswersController> logger)
    {
        _context = context;
        _manager = manager;
        _logger = logger;
    }
    public IActionResult Index() => View(_context.Forms.ToArray());

    public async Task<IActionResult> Fill(string id)
    {
        try
        {
            var form = await _context.Forms.FirstOrDefaultAsync(f => f.Id == id);
            if (form is null) return NotFound();
            var vm = new FillFormViewModel
            {
                FormId = form.Id,
                Answers = new (await _manager.GenerateAnswers(form.Id)),
                FormTitle = form.Title,
                FormDescription = form.Description,
            };
            return View(vm);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Warning, e.Message);
            return NotFound();
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Fill([FromForm] FillFormViewModel formViewModel)
    {
        if (!ModelState.IsValid)
            return View(formViewModel);
        var form = await _context.Forms.FirstOrDefaultAsync(f => f.Id == formViewModel.FormId);
        if (form is null) 
            return NotFound();

        var fa = new FormAnswers 
        { 
            Answers = formViewModel.Answers,
            Form = form,
        };
        await _context.AddAsync(fa);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> See(string id)
    {
        var form = await _context.Forms.Include(f => f.FormAnswers).FirstOrDefaultAsync(f => f.Id == id);
        if (form is null) return NotFound();


        return View(form.FormAnswers);
    }
    public async Task<IActionResult> Details(string id)
    {
        var answer = await _context.FormAnswers.Include(f => f.Form).Include(f => f.Answers).FirstOrDefaultAsync(f => f.Id == id);
        if (answer is null) return NotFound();

        return View(answer);
    }

}
