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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Forms.Mvc.Controllers;

public class AnswersController : Controller
{
    private readonly IMediator _mediator;

    public AnswersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IActionResult> Index(int page = 0, int count = 10, string? searchText = "")
    {
        var result = await _mediator.Send(new GetFormListQuery { Count = count, Page = page, SearchText = searchText ?? "" });
        return View(result);
    }
    /*public async Task<IActionResult> Answers(string formId)
    {
        var result = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId });
        return View(result);
    }*/
    public async Task<IActionResult> Fill(string formId)
    {
        var command = await _mediator.Send(new GetEmptyFormQuery { FormId = formId, UserId = "anon" });
        //var form = await _mediator.Send(new GetFormQuery { Id = formId });

        var cvm = new FillFormViewModel(command);
        return View(cvm);
    }
    public async Task<IActionResult> UpdateStringAnswer([Bind] StringAnswer answer)
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
            UserId = "anon",
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
    public async Task<IActionResult> CompleteForm(string formId)
    {
        var result = await _mediator.Send(new CreateFormAnswersCommand { FormId = formId, UserId = "anon" });
        if (result is null)
            return RedirectToAction("Index", "Home");
        
        return RedirectToAction(nameof(Fill), routeValues: new { formId = result.FormId });
    }


}
