namespace DomraSinForms.Domain.Models.Questions;
public class TextQuestion : QuestionBase
{
    public TextQuestionType Type { get; set; }
}
public enum TextQuestionType
{
    Text, Number, Date, Time, DateTime
}