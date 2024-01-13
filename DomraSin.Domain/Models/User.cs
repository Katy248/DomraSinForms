namespace DomraSin.Domain.Models;

public class User : EntityBase
{
    public string Name { get; set; }
    public string? Nickname { get; set; }
    public string Email { get; set; }
    public bool Verified { get; set; }
    public string PasswordHash { get; set; }
}
