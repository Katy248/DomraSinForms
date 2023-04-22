using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Domain.Models.Answers;

public class Answer : DbEntity
{
    public QuestionBase Question { get; set; }
    public virtual string Value { get; set; }
}
