namespace DomraSin.Domain;

public class Answer : EntityBase
{
    public Question Question { get; set; }
    public string Value { get; set; }
}

