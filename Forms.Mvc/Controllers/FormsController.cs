using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomraSinForms.Domen.Models;
using Forms.Mvc.Data;
using Microsoft.AspNetCore.Authorization;
using Forms.Mvc.Models;
using MediatR;
using DomraSinForms.Application.Forms.Queries.GetList;
using GewelleWorks.MVC.Controllers;
using DomraSinForms.Application.Forms.Commands.Create;
using DomraSinForms.Application.Forms.Commands.Delete;
using DomraSinForms.Application.Forms.Commands.Update;
using DomraSinForms.Application.Forms.Queries.Get;
using AutoMapper;

namespace Forms.Mvc.Controllers;

[Authorize, Route("{controller}/{action=Index}")]
public class FormsController : MvcCRUDController<Form, CreateFormCommand, GetFormQuery, GetFormListQuery, UpdateFormCommand, DeleteFormCommand>
{
    private readonly ApplicationDbContext _context;

    public FormsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

   /* [HttpGet("{page}&{count}")]
    public async Task<IActionResult> Index(int page = 0, int count = 10)
    {
        return View(await GetEntityList(new GetFormListQuery { Page = page, Count = count }));
    }*/


    /* public async Task<IActionResult> Index()
     {
         return _context.Forms != null ?
                     View(await _context.Forms.Where(f => !f.IsDeleted).ToListAsync()) :
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
             form.IsDeleted = true;
             _context.Forms.Update(form);
         }

         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
     }

     private bool FormExists(string id)
     {
         return (_context.Forms?.Any(e => e.Id == id)).GetValueOrDefault();
     }
     #region Questions
     // GET: Forms/CreateQuestion/5
     [HttpGet("{id}")]
     public IActionResult CreateQuestion(string id)
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
             return RedirectToAction(nameof(Edit), routeValues: new { id = questionViewModel.FormId });
         }
         return View(questionViewModel);
     }
     [HttpGet("{id}/{formId}")]
     public async Task<IActionResult> EditQuestion(string id, string formId)
     {
         var question = await _context.Questions.FindAsync(id);
         if (question is not null)
             return View(new EditQuestionViewModel { FormId = formId, Question = question });

         return RedirectToAction(nameof(Edit), routeValues: new { id = formId });
     }
     [HttpPost]
     public async Task<IActionResult> EditQuestion([FromForm] EditQuestionViewModel questionViewModel)
     {
         if (!ModelState.IsValid)
             return View(questionViewModel);
         var question = await _context.Questions.FindAsync(questionViewModel.Question.Id);
         if (question is not null)
         {
             question.IsRequired = questionViewModel.Question.IsRequired;
             question.Text = questionViewModel.Question.Text;
             _context.Questions.Update(question);
             await _context.SaveChangesAsync();
         }
         return RedirectToAction(nameof(Edit), routeValues: new { id = questionViewModel.FormId });
     }
     [HttpPost("{id}/{formId}")]
     public async Task<IActionResult> DeleteQuestion(string id, string formId)
     {
         var question = await _context.Questions.FindAsync(id);
         if (question is not null)
         {
             _context.Remove(question);
             await _context.SaveChangesAsync();
         }
         return RedirectToAction(nameof(Edit), routeValues: new { id = formId });
     }

     #endregion*/
}
