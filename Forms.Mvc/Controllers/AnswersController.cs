using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Application.Forms.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

public class AnswersController : Controller
{
    private readonly IMediator _mediator;

    public AnswersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    //[HttpGet("{page?}/{count?}/{searchText?}")]
    public async Task<IActionResult> Index(int page = 0, int count = 10, string? searchText = "")
    {
        var result = await _mediator.Send(new GetFormListQuery { Count = count, Page = page, SearchText = searchText ?? "" });
        return View(result);
    }
    //[HttpGet("{formId}")]
    public async Task<IActionResult> Answers(string formId)
    {
        var result = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId });
        return View(result);
    }
}
