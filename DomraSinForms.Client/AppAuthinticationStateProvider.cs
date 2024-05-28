using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.IdentityModel.JsonWebTokens;

namespace DomraSinForms.Client;

public class AppAuthinticationStateProvider : AuthenticationStateProvider
{
    private const string AuthTokenKey = "AUTH_TOKEN";
    private static readonly AuthenticationState NotAuthorized = new(new(new ClaimsIdentity()));
    private readonly ProtectedLocalStorage _localStorage;

    public AppAuthinticationStateProvider(ProtectedLocalStorage localStorage)
    {
        _localStorage = localStorage;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetAsync<string>(AuthTokenKey);
        if (token.Value is null)
            return NotAuthorized;
        
        JwtSecurityTokenHandler handler = new();
        var jwt = handler.ReadJwtToken(token.Value);

        return new AuthenticationState(new(new ClaimsIdentity(jwt.Claims)));
    }
}