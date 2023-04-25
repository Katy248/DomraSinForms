namespace DomraSinForms.Domain.Models.Questions;
public abstract class QuestionBase : DbEntity
{
    public string QuestionText { get; set; }
    public int Index { get; set; }
    public Form Form { get; set; }
}
