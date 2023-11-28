namespace DomraSin.Domain.Models;

public class Question : FormItem
{
    public Form Form { get; set; }
    public string Text { get; set; }
    public IEnumerable<QuestionOption> Options { get; set; }

    public bool IsRequired { get; set; }
}

public enum QuestionType
{
    Text,
    RichText,
    Number,
    Radio,
    Check,
    Select
}
