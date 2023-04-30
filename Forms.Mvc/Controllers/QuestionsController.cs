using DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
using DomraSinForms.Application.Questions.Commands.CreateTextQuestion;
using DomraSinForms.Application.Questions.Commands.Delete;
using DomraSinForms.Application.Questions.Commands.UpdateOptionsQuestion;
using DomraSinForms.Application.Questions.Commands.UpdateTextQuestion;
using DomraSinForms.Domain.Models.Questions;
using Forms.Mvc.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

public class QuestionsController : Controller
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateTextQuestion([Bind] EditFormViewModel viewModel)
    {
        //if (!string.IsNullOrWhiteSpace(viewModel.CreateTextQuestionCommand.QuestionText))
            await _mediator.Send(viewModel.CreateTextQuestionCommand);

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = viewModel.CreateTextQuestionCommand.FormId });
    }
    [HttpPost]
    public async Task<IActionResult> CreateOptionsQuestion([Bind] CreateOptionsQuestionCommand command)
    {
        await _mediator.Send(command);

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = command.FormId });
    }
    [HttpPost]
    public async Task<IActionResult> UpdateTextQuestion([Bind] UpdateTextQuestionViewModel viewModel)
    {
        var q = await _mediator.Send(viewModel.Command);

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = q.FormId });
    }
    [HttpPost]
    public async Task<IActionResult> UpdateOptionsQuestion([Bind] EditFormViewModel viewModel)
    {
        var q = await _mediator.Send(viewModel.UpdateOptionsQuestionCommand);

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = q.FormId });
    }
    [HttpPost]
    public async Task<IActionResult> Delete(string id, string formId)
    {
        var q = await _mediator.Send(new DeleteQuestionCommand { Id = id });

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = formId });
    }
    [HttpPost]
    public IActionResult AddNewOption()
    {
        return PartialView("/Views/Questions/_OptionPartial.cshtml", new QuestionOption());
    }
}
