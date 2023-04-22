namespace DomraSinForms.Domain.Models.Questions;
public abstract class QuestionBase : DbEntity
{
    public string QuestionText { get; set; }
}
