using DomraSinForms.Domain.Models.Questions;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands;
public class CreateQuestionBaseCommand
{
    public string FormId { get; set; }
    public string QuestionText { get; set; } = "";
    public bool IsRequired { get; set; } = false;
}
public class CreateQuestionBaseCommand<TQuestion> : CreateQuestionBaseCommand, IRequest<TQuestion> where TQuestion : QuestionBase
{

}
