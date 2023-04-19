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
    public virtual async Task<IActionResult> GetList([FromBody] TRetrieveListQuery query) =>
        Ok(await _mediator.Send(query));
    public virtual async Task<IActionResult> Get([FromBody] TRetrieveSingleQuery query) =>
        Ok(await _mediator.Send(query));
    [HttpPost]
    public virtual async Task<IActionResult> CreateEntity([FromBody] TCreateCommand command)
    {
        if (!ModelState.IsValid)
            return Problem(ModelState.ValidationState.ToString());

        return Ok(await _mediator.Send(command));
    }
    [HttpPost]
    public virtual async Task<IActionResult> UpdateEntity([FromBody] TUpdateCommand command)
    {
        if (!ModelState.IsValid)
            return View(command);

        return Ok(await _mediator.Send(command));
    }
    [HttpPost]
    public virtual async Task<IActionResult> DeleteEntity([FromBody] TDeleteCommand command)
    {
        if (!ModelState.IsValid)
            return View(command);

        return Ok(await _mediator.Send(command));
    }
}
