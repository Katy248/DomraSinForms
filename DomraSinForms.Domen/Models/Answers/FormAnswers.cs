namespace DomraSinForms.Domain.Models.Answers;
public class FormAnswers : DbEntity
{
    public string FormId { get; set; }
    public List<Answer> Answers { get; set; } = new();
}
