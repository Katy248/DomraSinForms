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
    private readonly SignInManager<IdentityUser> _signIn;

    public FormsController(IMediator mediator, SignInManager<IdentityUser> signIn)
    {
        _mediator = mediator;
        _signIn = signIn;
    }
    public async Task<IActionResult> Index(int page = 0, int count = 10, string searchText = "")
    {
        var forms = await _mediator.Send(new GetFormListQuery { Count = count, Page = page, SearchText = searchText });

        return View(forms);
    }

    [Authorize]
    public IActionResult Create()
    {
        var userId = _signIn.UserManager.GetUserId(User);
        if (userId is null)
            return RedirectToIndex();

        var command = new CreateFormCommand { CreatorId = userId };

        return View(command);
    }
    [HttpPost]
    public async Task<IActionResult> Create([Bind] CreateFormCommand command)
    {
        if (!ModelState.IsValid)
            return View(command);

        await _mediator.Send(command);

        return RedirectToIndex();
    }
    public async Task<IActionResult> Edit(string id)
    {
        var form = await _mediator.Send(new GetFormQuery { Id = id });

        if (form is null)
            return RedirectToIndex();

        return View(new EditFormViewModel { Form = form, UpdateFormCommand = new UpdateFormCommand { Id = form.Id, Description = form.Description, Title = form.Title } });
    }
    [HttpPost]
    public async Task<IActionResult> Edit([Bind] EditFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Edit), routeValues: new { Id = viewModel.UpdateFormCommand.Id });

        await _mediator.Send(viewModel.UpdateFormCommand);

        return RedirectToAction(nameof(Edit), routeValues: new { Id = viewModel.UpdateFormCommand.Id });
    }
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new DeleteFormCommand { Id = id };
        await _mediator.Send(command);

        return RedirectToIndex();
    }
    protected IActionResult RedirectToIndex()
    {
        return RedirectToAction(nameof(Index));
    }
}
