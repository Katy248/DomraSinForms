/*using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Api.Controllers;

[ApiController, Route("api/[controller]/[action]")]
public class CRUDController<TEntity, TCreateCommand, TRetrieveSingleQuery, TRetrieveListQuery, TUpdateCommand, TDeleteCommand> : Controller
    where TCreateCommand : IRequest<TEntity>, new()
    where TRetrieveSingleQuery : IGetSingleRequest<TEntity>, new()
    where TRetrieveListQuery : IRequest<IEnumerable<IMapWith<TEntity>>>, new()
    where TUpdateCommand : IUpdateRequest<TEntity>, new()
    where TDeleteCommand : IDeleteRequest, new()
{
    protected readonly IMediator _mediator;

    public CRUDController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public virtual async Task<IEnumerable<IMapWith<TEntity>>> GetList([FromBody] TRetrieveListQuery query)
    {
        return await _mediator.Send(query);
    }
    [HttpPost]
    public virtual async Task<TEntity> Get([FromBody] TRetrieveSingleQuery query)
    {
        return await _mediator.Send(query);
    }
    [HttpPost]
    public virtual async Task<TEntity> Create([FromBody] TCreateCommand command)
    {
        return await _mediator.Send(command);
    }
    [HttpPost]
    public virtual async Task<TEntity> Update([FromBody] TUpdateCommand command)
    {
        return await _mediator.Send(command);
    }
    [HttpPost]
    public virtual async Task<bool> Delete([FromBody] TDeleteCommand command)
    {
        return await _mediator.Send(command);
    }
}
*/