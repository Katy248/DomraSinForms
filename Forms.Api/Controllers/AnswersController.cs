using DomraSinForms.Application.Answers.Commands.Create;
using DomraSinForms.Domain.Models.Answers;
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

    [HttpPost]
    public async Task<FormAnswers> Get()
    {
        return null;
    }
    [HttpPost]
    public async Task<IEnumerable<FormAnswers>> GetList()
    {
        return null;
    }
    [HttpPost]
    public async Task<CreateFormAnswersCommand> GetEmptyForm()
    {
        return null;
    }
}
