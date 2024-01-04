namespace DomraSin.Domain.Models;
public class QuestionOption : EntityBase
{
    public string Value { get; set; }
    public ScoreType ScoreType { get; set; }
    public int Score { get; set; }
}
