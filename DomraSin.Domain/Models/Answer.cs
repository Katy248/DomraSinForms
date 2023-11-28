namespace DomraSin.Domain.Models;

public class Answer : EntityBase
{
    public Question Question { get; set; }
    public string Value { get; set; }
}

