using System;

namespace DomraSinForms.Domain.Models;

public class User
{
    public UserId Id { get; set; }
    public string Name { get; set; }
    public string? Nickname { get; set; }
    public string Email { get; set; }
    public bool Verified { get; set; }
    public string PasswordHash { get; set; }

    public static User CreateNew(string name, string email, string passwordHash, bool verified = false) =>
        new User
        {
            Id = new(Guid.NewGuid()),
            Name = name,
            Email = email,
            Verified = verified,
            PasswordHash = passwordHash,
        };
}

public readonly record struct UserId(Guid Value);

public record PrivateUserData(UserId Id, string Username, string? Nickname, string Email)
{
    public static PrivateUserData GetFromUser(User user) =>
        new(user.Id, user.Name, user.Nickname, user.Email);
}
public record PublicUserData(UserId Id, string Username)
{
    public static PublicUserData GetFromUser(User user) =>
        new(user.Id, user.Name);
}
