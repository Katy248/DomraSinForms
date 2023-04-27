using DomraSinForms.Application.Forms.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

public class FormsController : Controller
{
    private readonly IMediator _mediator;

    public FormsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("{page?}/{count?}/{searchText?}")]
    public async Task<IActionResult> Index(int page = 0, int count = 10, string? searchText = "")
    {
        var result = await _mediator.Send(new GetFormListQuery { Count = count, Page = page, SearchText = searchText ?? "" });
        return View(result);
    }
}
