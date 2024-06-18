using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using JwtConstants = Microsoft.IdentityModel.JsonWebTokens.JwtConstants;

namespace DomraSinForms.Client;

public class AppAuthenticationStateProvider : AuthenticationStateProvider
{
    private const string AuthTokenKey = "DOMRA_SIN_FORMS_AUTH_TOKEN";
    private static readonly AuthenticationState NotAuthorized = new(new(new ClaimsIdentity()));

    private readonly ProtectedLocalStorage _localStorage;
    private readonly ISender _sender;
    private readonly ILogger<AppAuthenticationStateProvider> _logger;


    public AppAuthenticationStateProvider(ProtectedLocalStorage localStorage, ISender sender,
        ILogger<AppAuthenticationStateProvider> logger)
    {
        _localStorage = localStorage;
        _sender = sender;
        _logger = logger;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string? token = null;
        try
        {
            token = (await _localStorage.GetAsync<string>(AuthTokenKey)).Value;
            _logger.LogInformation($"JwtToken: {token}");
        }
        catch
        {
            return NotAuthorized;
        }

        if (token is null)
            return NotAuthorized;

        JwtSecurityTokenHandler handler = new();
        var jwt = handler.ReadJwtToken(token);
        var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, JwtBearerDefaults.AuthenticationScheme)));
        _logger.LogInformation($"State {state.User.Identity.IsAuthenticated}");
        return state;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>True if login is success, otherwise false</returns>
    public async Task<bool> Login(string email, string password)
    {
        var responce = await _sender.Send(new DomraSinForms.Application.Features.Users.Login.Request(email, password));
        if (responce is not null)
        {
            await _localStorage.SetAsync(AuthTokenKey, responce.JwtToken);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return true;
        }

        return false;
    }
}