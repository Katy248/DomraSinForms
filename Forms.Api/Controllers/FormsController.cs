using DomraSinForms.Application.Forms.Commands.Create;
using DomraSinForms.Application.Forms.Commands.Delete;
using DomraSinForms.Application.Forms.Commands.Update;
using DomraSinForms.Application.Forms.Queries.Get;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Api.Controllers;

public class FormsController : CRUDController<Form, CreateFormCommand, GetFormQuery, GetFormListQuery, UpdateFormCommand, DeleteFormCommand>
{
    public FormsController(IMediator mediator) : base(mediator)
    {
    }
}
