using AutoMapper;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

public class CRUDController<TEntity, TCreateCommand, TRetrieveSingleQuery, TRetrieveListQuery, TUpdateCommand, TDeleteCommand> : Controller
    where TCreateCommand : IRequest<TEntity>, new ()
    where TRetrieveSingleQuery : IGetSingleRequest<TEntity>, new ()
    where TRetrieveListQuery : IRequest<IEnumerable<IMapWith<TEntity>>>, new ()
    where TUpdateCommand : IUpdateRequest<TEntity>, new ()
    where TDeleteCommand : IDeleteRequest, new ()
{
    protected readonly IMediator _mediator;

    public CRUDController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public virtual async Task<IEnumerable<IMapWith<TEntity>>> GetEntityList(TRetrieveListQuery query)
    {
        return await _mediator.Send(query);
    }
    public virtual async Task<TEntity> GetEntity(TRetrieveSingleQuery query)
    {
        return await _mediator.Send(query);
    }
    public virtual async Task<TEntity> CreateEntity(TCreateCommand command)
    {
        return await _mediator.Send(command);
    }
    public virtual async Task<TEntity> UpdateEntity(TUpdateCommand command)
    {
        return await _mediator.Send(command);
    }
    public virtual async Task<bool> DeleteEntity(TDeleteCommand command)
    {
        return await _mediator.Send(command);
    }
}
