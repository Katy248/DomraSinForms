using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.CreateTextQuestion;
public class CreateTextQuestionCommand : CreateQuestionBaseCommand<TextQuestion>
{
    public TextQuestionType Type { get; set; }

    public static CreateTextQuestionCommand FromQuestion(TextQuestion q)
    {
        return new()
        {
            FormId = q.FormId,
            QuestionText = q.QuestionText,
            IsRequired = q.IsRequired,
            Type = q.Type,
        };
    }
}
