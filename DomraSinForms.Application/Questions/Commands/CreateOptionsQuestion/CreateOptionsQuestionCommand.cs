using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
public class CreateOptionsQuestionCommand : CreateQuestionBaseCommand<OptionsQuestion>
{
    public ICollection<QuestionOption> Options { get; set; }
    public bool AllowMultipleChoice { get; set; }
}
