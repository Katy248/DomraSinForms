using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomraSinForms.Domen.Models;
using Forms.Mvc.Data;
using Microsoft.AspNetCore.Authorization;
using Forms.Mvc.Models;

namespace Forms.Mvc.Controllers;

[Authorize]
public class FormsController : Controller
{
    private readonly ApplicationDbContext _context;

    public FormsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Forms
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
          return _context.Forms != null ? 
                      View(await _context.Forms.ToListAsync()) :
                      Problem("Entity set 'ApplicationDbContext.Forms'  is null.");
    }

    // GET: Forms/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null || _context.Forms == null)
        {
            return NotFound();
        }

        var form = await _context.Forms.Include(f => f.Questions).FirstOrDefaultAsync(f => f.Id == id);

        if (form == null)
        {
            return NotFound();
        }

        return View(form);
    }

    // GET: Forms/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Forms/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] Form form)
    {
        if (ModelState.IsValid)
        {
            _context.Add(form);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(form);
    }

    // GET: Forms/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null || _context.Forms == null)
        {
            return NotFound();
        }

        var form = await _context.Forms.Include(f => f.Questions).FirstAsync(f => f.Id == id);
        if (form == null)
        {
            return NotFound();
        }
        return View(form);
    }

    // POST: Forms/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Title,Description,CreatorId,Id")] Form form)
    {
        if (id != form.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(form);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(form.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(form);
    }
    // GET: Forms/CreateQuestion/5
    public async Task<IActionResult> CreateQuestion(string id)
    {
        return View(new CreateQuestionViewModel { FormId = id, Question = new() });
    }
    // POST: Forms/CreateQuestion/
    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromForm] CreateQuestionViewModel questionViewModel)
    {
        if (!ModelState.IsValid)
            return View(questionViewModel);
        var form = await _context.Forms.Include(f => f.Questions).FirstAsync(f => f.Id == questionViewModel.FormId);
        if (form is not null)
        {
            form.Questions.Add(questionViewModel.Question);
            _context.Update(form);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), routeValues: questionViewModel.FormId);
        }
        return View(questionViewModel);
    }

    // GET: Forms/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null || _context.Forms == null)
        {
            return NotFound();
        }

        var form = await _context.Forms
            .FirstOrDefaultAsync(m => m.Id == id);
        if (form == null)
        {
            return NotFound();
        }

        return View(form);
    }

    // POST: Forms/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        if (_context.Forms == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Forms'  is null.");
        }
        var form = await _context.Forms.FindAsync(id);
        if (form != null)
        {
            _context.Forms.Remove(form);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FormExists(string id)
    {
      return (_context.Forms?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
