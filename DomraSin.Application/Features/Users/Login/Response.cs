namespace DomraSin.Application.Features.Users.Login;

internal record Response(bool IsSuccess, string? JwtToken = null)
{
    public static readonly Response Failed = new(false);
};