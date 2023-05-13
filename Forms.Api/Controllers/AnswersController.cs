using DomraSinForms.Application.Answers.Commands.Create;
using DomraSinForms.Application.Answers.Queries.Get;
using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Application.Mapper;
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
    public async Task<FormAnswers> Get([FromBody] GetFormAnswersQuery query)
    {
        return await _mediator.Send(query);
    }
    [HttpPost]
    public async Task<IEnumerable<IMapWith<FormAnswers>>> GetList([FromBody] GetFormAnswersListQuery query)
    {
        return await _mediator.Send(query);
    }
    /*[HttpPost]
    public async Task<CreateFormAnswersCommand> GetEmptyForm([FromBody] GetEmptyFormQuery query)
    {
        return await _mediator.Send(query);
    }*/
    [HttpPost]
    public async Task<FormAnswers> Create([FromBody] CreateFormAnswersCommand command)
    {
        return await _mediator.Send(command);
    }
}
