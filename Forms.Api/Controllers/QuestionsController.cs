using DomraSinForms.Application.Questions.Commands.Create;
using DomraSinForms.Application.Questions.Commands.Delete;
using DomraSinForms.Application.Questions.Commands.Update;
using DomraSinForms.Application.Questions.Queries.Get;
using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Api.Controllers;

public class QuestionsController : CRUDController<QuestionBase, CreateQuestionCommand, GetQuestionQuery, GetQuestionListQuery, UpdateQuestionCommand, DeleteQuestionCommand>
{
    public QuestionsController(IMediator mediator) : base(mediator)
    {
    }
    [NonAction]
    public override Task<QuestionBase> Create([FromBody] CreateQuestionCommand command)
    {
        throw new NotImplementedException();
    }
}
