using DomraSinForms.Domen.Models.Questions;

namespace DomraSinForms.Domen.Models.Answers;

public class Answer : DbEntity
{
    public QuestionBase Question { get; set; }
    public virtual string Value { get; set; }
}
