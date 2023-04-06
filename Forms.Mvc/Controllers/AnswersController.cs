using Forms.Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Controllers;

public class AnswersController : Controller
{
    private readonly ApplicationDbContext _context;

    public AnswersController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index() => View();

    public async Task<IActionResult> Fill(string id)
    {
        var form = await _context.Forms.Include(f => f.Questions).FirstOrDefaultAsync(f => f.Id == id);
        if (form is not null)
        {
            return View(form);
        }
        return RedirectToAction(nameof(Index));
    }
    public IActionResult See(string id)
    {
        return View();
    }
}
