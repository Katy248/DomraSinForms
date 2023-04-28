using DomraSinForms.Domain.Models.Questions;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands;
public class UpdateQuestionBaseCommand
{
    public string Id { get; set; }
    public string QuestionText { get; set; }
    public bool IsRequired { get; set; }
    public int Index { get; set; }
}
public class UpdateQuestionBaseCommand<TQuestion> : UpdateQuestionBaseCommand, IRequest<TQuestion> where TQuestion : QuestionBase
{

}
