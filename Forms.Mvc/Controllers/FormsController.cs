using DomraSinForms.Application.Forms.Commands.Create;
using DomraSinForms.Application.Forms.Commands.Update;
using DomraSinForms.Application.Forms.Queries.Get;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Persistence;
using Forms.Mvc.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Forms.Mvc.Controllers;

public class FormsController : Controller
{
    private readonly IMediator _mediator;
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<IdentityUser> _signIn;

    public FormsController(IMediator mediator, ApplicationDbContext context, SignInManager <IdentityUser> signIn)
    {
        _mediator = mediator;
        _context = context;
        _signIn = signIn;
    }
    /* [HttpGet("{page?}/{count?}/{searchText?}")]*/
    public async Task<IActionResult> Index(int page = 0, int count = 10, string? searchText = "")
    {
        var result = await _mediator.Send(new GetFormListQuery { Count = count, Page = page, SearchText = searchText ?? "" });
        return View(result);
    }

    public IActionResult Create()
    {
        var command = new CreateFormCommand { CreatorId = _signIn.UserManager.GetUserId(User) };
        return View(command);
    }
    [HttpPost]
    public async Task<IActionResult> Create([Bind("CreatorId, Title, Description")] CreateFormCommand command)
    {
        if(!ModelState.IsValid)
        {
            return View(command);
        }
        var result = await _mediator.Send(command);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Edit(string id) 
    {
        var result = await _mediator.Send(new GetFormQuery { Id = id });
        return View(new EditFormViewModel {Form = result, UpdateFormCommand = new UpdateFormCommand { Id = result.Id, Description = result.Description, Title = result.Title} }); 
    }
    [HttpPost]
    public IActionResult Edit([Bind] EditFormViewModel command) 
    {
    if (!ModelState.IsValid)
        {
            return RedirectToAction("Edit", routeValues: new { Id = command.UpdateFormCommand.Id });
        }
        _mediator.Send(command.UpdateFormCommand);
        return RedirectToAction("Edit", routeValues: new {Id = command.UpdateFormCommand.Id});
    }
}
