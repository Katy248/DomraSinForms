namespace DomraSin.Domain.Models;
public class EntityBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}

