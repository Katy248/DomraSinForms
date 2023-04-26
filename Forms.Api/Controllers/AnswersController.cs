using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Api.Controllers;

[ApiController, Route("api/[controller]/[action]")]
public class AnswersController : Controller
{
    private readonly IMediator _mediator;

    public AnswersController(IMediator mediator)
    {
        _mediator = mediator;
    } 
}
