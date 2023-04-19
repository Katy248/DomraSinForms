using DomraSinForms.Application.Forms.Commands.Create;
using DomraSinForms.Application.Forms.Commands.Delete;
using DomraSinForms.Application.Forms.Commands.Update;
using DomraSinForms.Application.Forms.Queries.Get;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Domen.Models;
using MediatR;

namespace Forms.Mvc.Controllers;

public class YAFormsController : CRUDController<Form, CreateFormCommand, GetFormQuery, GetFormListQuery, UpdateFormCommand, DeleteFormCommand>
{
    public YAFormsController(IMediator mediator) : base(mediator)
    {
    }
}
