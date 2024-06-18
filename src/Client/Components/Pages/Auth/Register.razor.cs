using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using DomraSinForms.Application.Features.Users.Register;

namespace DomraSinForms.Client.Components.Pages.Auth;

public class RegisterViewModel
{
    public RegisterUserData Data = new();
    public Request Request => new(Data.Username, Data.Email, Data.Password);
}

public class RegisterUserData
{
    [Required, MinLength(2), MaxLength(256)] public string Username { get; set; } = "";
    [Required, EmailAddress, MinLength(8), MaxLength(256)] public string Email { get; set; }
    [Required, MinLength(8, ErrorMessage = "Password must be at list 8 characters long.")] public string Password { get; set; }
    [Required, Compare(nameof(Password), ErrorMessage = "Passwords do not match")] public string PasswordConfirmation { get; set; }
}
