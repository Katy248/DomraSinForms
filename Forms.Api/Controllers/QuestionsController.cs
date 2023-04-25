using DomraSinForms.Application.Questions.Commands;
using DomraSinForms.Application.Questions.Commands.Delete;
using DomraSinForms.Application.Questions.Commands.Update;
using DomraSinForms.Application.Questions.Queries.Get;
using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Api.Controllers;

public class QuestionsController : CRUDController<QuestionBase, CreateQuestionBaseCommand, GetQuestionQuery, GetQuestionListQuery, UpdateQuestionCommand, DeleteQuestionCommand>
{
    public QuestionsController(IMediator mediator) : base(mediator)
    {
    }
    [NonAction]
    public override Task<QuestionBase> Create([FromBody] CreateQuestionBaseCommand command)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override Task<QuestionBase> Update([FromBody] UpdateQuestionCommand command)
    {
        throw new NotImplementedException();
    }
}
