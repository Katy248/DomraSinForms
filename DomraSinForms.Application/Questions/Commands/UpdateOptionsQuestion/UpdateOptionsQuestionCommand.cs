using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.UpdateOptionsQuestion;
public class UpdateOptionsQuestionCommand : UpdateQuestionBaseCommand<OptionsQuestion>
{
    public ICollection<QuestionOption> Options { get; set; }
    public bool AllowMultipleChoice { get; set; }
}
