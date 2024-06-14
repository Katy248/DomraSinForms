using System.ComponentModel.DataAnnotations;

namespace DomraSinForms.Client.Components.Pages.Auth;

public class LoginViewModel
{
    public LoginData Data { get; set; } = new();
}

public class LoginData
{
    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; set; }

    [Required, MinLength(8), MaxLength(256)]
    public string Password { get; set; }
}