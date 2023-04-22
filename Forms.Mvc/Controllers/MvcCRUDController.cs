using AutoMapper;
using DomraSinForms.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GewelleWorks.MVC.Controllers;

public class MvcCRUDController<TEntity, TCreateCommand, TRetrieveSingleQuery, TRetrieveListQuery, TUpdateCommand, TDeleteCommand> : Controller
    where TCreateCommand : IRequest<TEntity>, new()
    where TRetrieveSingleQuery : IGetSingleRequest<TEntity>, new()
    where TRetrieveListQuery : IGetListRequest<TEntity>, new()
    where TUpdateCommand : IUpdateRequest<TEntity>, new()
    where TDeleteCommand : IDeleteRequest, new()
{
    protected readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MvcCRUDController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("{page?}/{count?}/{searchText?}")]
    public virtual async Task<IActionResult> Index(int page = 0, int count = 10, string searchText = "")
    {
        var retrieveQuery = new TRetrieveListQuery
        {
            Page = page,
            Count = count,
            SearchText = searchText
        };
        return View(await _mediator.Send(retrieveQuery));
    }

    public virtual async Task<IActionResult> Create(string id)
    {
        return View(new TCreateCommand());
    }
    [HttpPost]
    public virtual async Task<IActionResult> Create([Bind] TCreateCommand command)
    {
        if (!ModelState.IsValid)
            return View(command);

        await _mediator.Send(command);

        return RedirectToAction(nameof(Index));
    }
    public virtual async Task<IActionResult> Edit(string id)
    {
        var updateCommand = _mapper.Map<TUpdateCommand>(await _mediator.Send(new TRetrieveSingleQuery { Id = id }));
        return View(updateCommand);
    }
    [HttpPost]
    public virtual async Task<IActionResult> Edit([Bind("Id,Description,Questions,Title")] TUpdateCommand command)
    {
        if (!ModelState.IsValid)
            return View(command);

        await _mediator.Send(command);

        return RedirectToAction(nameof(Index));
    }
    public virtual async Task<IActionResult> Delete(string id)
    {
        return View(new TDeleteCommand { Id = id });
    }
    [HttpPost]
    public virtual async Task<IActionResult> Delete([Bind] TDeleteCommand command)
    {
        if (!ModelState.IsValid)
            return View(command);

        await _mediator.Send(command);

        return RedirectToAction(nameof(Index));
    }

}
