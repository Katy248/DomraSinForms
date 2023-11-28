namespace DomraSin.Domain.Models;
public class QuestionOption : EntityBase
{
    public string Value { get; set; }
    public ScoreType Type { get; set; }
    public int Count { get; set; }
}
