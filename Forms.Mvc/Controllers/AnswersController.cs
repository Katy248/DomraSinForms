using DomraSinForms.Application.Answers.Commands.Create;
using DomraSinForms.Application.Answers.Commands.Update;
using DomraSinForms.Application.Answers.Queries.GetEmptyForm;
using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Application.Forms.Queries.Get;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Domain.Models.Answers;
using Forms.Mvc.Models;
using Forms.Mvc.Models.Answers;
using Forms.Mvc.Models.Answers.AnswersModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Identity.Client;

namespace Forms.Mvc.Controllers;

public class AnswersController : Controller
{
    private readonly IMediator _mediator;
    private readonly UserManager<IdentityUser> _userManager;

    public AnswersController(IMediator mediator, UserManager<IdentityUser> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }
    /*public async Task<IActionResult> Index(int page = 0, int count = 10, string? searchText = "")
    {
        var result = await _mediator.Send(new GetFormListQuery { Count = count, Page = page, SearchText = searchText ?? "" });
        return View(result);
    }*/
    /*public async Task<IActionResult> Answers(string formId)
    {
        var result = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId });
        return View(result);
    }*/
    public async Task<IActionResult> Fill(string formId)
    {
        var command = await _mediator.Send(new GetEmptyFormQuery { FormId = formId, UserId = _userManager.GetUserId(User) });
        //var form = await _mediator.Send(new GetFormQuery { Id = formId });

        var cvm = new FillFormViewModel(command);
        return View(cvm);
    }
    public async Task<IActionResult> UpdateStringAnswer([Bind] StringAnswer answer)
    {
        return (await UpdateForm(answer));
    }
    public async Task<IActionResult> UpdateDecimalAnswer([Bind] DecimalAnswer answer)
    {
        return (await UpdateForm(answer));
    }
    public async Task<IActionResult> UpdateDateAnswer([Bind] DateAnswer answer)
    {
        return (await UpdateForm(answer));
    }
    public async Task<IActionResult> UpdateTimeAnswer([Bind] TimeAnswer answer)
    {
        return (await UpdateForm(answer));
    }
    public async Task<IActionResult> UpdateDateTimeAnswer([Bind] DateTimeAnswer answer)
    {
        return (await UpdateForm(answer));
    }
    public async Task<IActionResult> UpdateCheckAnswer([Bind] CheckAnswer answer)
    {
        return (await UpdateForm(answer));
    }
    public async Task<IActionResult> UpdateRadioAnswer([Bind] RadioAnswer answer)
    {
        return (await UpdateForm(answer));
    }
    public async Task<IActionResult> UpdateForm(IAnswerViewModel viewModel)
    {
        var result = await _mediator.Send(new UpdateFormAnswersCommand 
        { 
            FormId = viewModel.FormId, 
            UserId = _userManager.GetUserId(User),
            Answer = new()
            {
                QuestionId = viewModel.QuestionId,
                Value = viewModel.Value,
            }
        });
        if (result is not null)
            return RedirectToAction(nameof(Fill), routeValues: new { formId = result.FormId });

        return RedirectToAction("Index", "Home");
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CompleteForm(string formId)
    {
        var result = await _mediator.Send(new CreateFormAnswersCommand { FormId = formId, UserId = _userManager.GetUserId(User) });
        if (result is null)
            return RedirectToAction(nameof(Fill), routeValues: new { formId = formId });
        
        return RedirectToAction(nameof(AnsweredForm));
        
    }
    public IActionResult AnsweredForm()
    {
        return View();
    }

}
