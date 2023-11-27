namespace DomraSin.Domain;

public class Form : EntityBase
{
    public User Creator { get; set; }
    public IEnumerable<User> Redactors { get; set; }
    public string Name { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}

