namespace DomraSin.Domain.Models;
public class FormAnswers : EntityBase
{
    public Form Form { get; set; }
    public IEnumerable<Answer> Answers { get; set; }
    public User? User { get; set; }
}
