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
    public async Task<IActionResult> Answers(string formId)
    {
        var result = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId });
        return View(result);
    }
    public async Task<IActionResult> Fill(string formId)
    {
        var command = await _mediator.Send(new GetEmptyFormQuery { FormId = formId, UserId = "anon" });
        //var form = await _mediator.Send(new GetFormQuery { Id = formId });

        var cvm = new FillFormViewModel(command);
        return View(cvm);
    }
    [HttpPost("/string")]
    public async Task<IActionResult> UpdateForm([FromBody] StringAnswer answer)
    {
        var result = await UpdateForm(viewModel: answer);
        if (result is not null)
            return Ok(result);
        
        return BadRequest();
    }
    [HttpPost("/radio")]
    public async Task<IActionResult> UpdateForm([FromBody] RadioAnswer answer)
    {
        var result = await UpdateForm(viewModel: answer);
        if (result is not null)
            return Ok(result);
        
        return BadRequest();
    }
    public async Task<FormAnswers?> UpdateForm(IAnswerViewModel viewModel)
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
        return result;
    }
    [HttpPost]
    public async Task<IActionResult> CompleteForm(string formId)
    {
        var result = await _mediator.Send(new CreateFormAnswersCommand { Id = formId, UserId = "anon" });
        if (result is not null)
            return Ok(result);
        
        return BadRequest();
    }


}
