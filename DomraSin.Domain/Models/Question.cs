namespace DomraSin.Domain.Models;

public class Question : EntityBase
{
    public Form Form { get; set; }
    public string Text { get; set; }
    public IEnumerable<QuestionOption> Options { get; set; }
}

public enum QuestionType
{
    Text, Number, Radio, Check
}
