namespace DomraSin.Domain;

public class Form : EntityBase
{
    public string Name { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}

