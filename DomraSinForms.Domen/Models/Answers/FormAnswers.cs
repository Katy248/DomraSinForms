namespace DomraSinForms.Domain.Models.Answers;
public class FormAnswers : DbEntity
{
    public Form Form { get; set; } = new();
    public List<Answer> Answers { get; set; } = new();
}
