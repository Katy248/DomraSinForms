using DomraSinForms.Application.Forms.Commands.Create;
using DomraSinForms.Application.Forms.Commands.Delete;
using DomraSinForms.Application.Forms.Commands.Update;
using DomraSinForms.Application.Forms.Queries.Get;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Persistence;
using Forms.Mvc.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Forms.Mvc.Controllers;

public class FormsController : Controller
{
    private readonly IMediator _mediator;
    private readonly SignInManager<IdentityUser> _signInManager;

    public FormsController(IMediator mediator, SignInManager<IdentityUser> signInManager)
    {
        _mediator = mediator;
        _signInManager = signInManager;
    }
    [Authorize]
    public async Task<IActionResult> Index(int page = 0, int count = 10, string searchText = "")
    {
        var userId = _signInManager.UserManager.GetUserId(User);
        if (userId is null)
            return RedirectToIndex();

        var forms = await _mediator.Send(
            new GetFormListQuery
            {
                Count = count,
                Page = page,
                SearchText = searchText,
                UserId = userId
            });

        return View(forms);
    }

    [Authorize]
    public IActionResult Create()
    {
        var userId = _signInManager.UserManager.GetUserId(User);
        if (userId is null)
            return RedirectToIndex();

        var command = new CreateFormCommand { CreatorId = userId };

        return View(command);
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Create([Bind] CreateFormCommand command)
    {
        if (!ModelState.IsValid)
            return View(command);

        await _mediator.Send(command);

        return RedirectToIndex();
    }
    [Authorize]
    public async Task<IActionResult> Edit(string id)
    {
        var userId = _signInManager.UserManager.GetUserId(User);
        if (userId is null)
            return RedirectToIndex();

        var form = await _mediator.Send(new GetFormQuery { Id = id, UserId = userId });

        if (form is null)
            return RedirectToIndex();

        return View(
            new EditFormViewModel 
            { 
                Form = form, 
                UpdateFormCommand = new UpdateFormCommand 
                { 
                    Id = form.Id, 
                    Description = form.Description, 
                    Title = form.Title, 
                    UserId = userId 
                } 
            });
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Edit([Bind] UpdateFormCommand command)
    {
        if (ModelState.IsValid)
            await _mediator.Send(command);

        return RedirectToAction(nameof(Edit), routeValues: new { Id = command.Id });
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var userId = _signInManager.UserManager.GetUserId(User);
        if (userId is null)
            return RedirectToIndex();

        var command = new DeleteFormCommand { Id = id, UserId = userId };
        await _mediator.Send(command);

        return RedirectToIndex();
    }
    protected IActionResult RedirectToIndex()
    {
        return RedirectToAction(nameof(Index));
    }
}
