using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using LoginFeature = DomraSinForms.Application.Features.Users.Login;

namespace DomraSinForms.Client;

public class AppAuthenticationStateProvider : AuthenticationStateProvider
{
    private const string AuthTokenKey = "DOMRA_SIN_FORMS_AUTH_TOKEN";
    private static readonly ClaimsPrincipal Anonymous = new(new ClaimsIdentity());

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
        //return new(httpContextAccessor.HttpContext?.User ?? Anonymous);

        // string? token = null;
        try
        {
            var token = (await _localStorage.GetAsync<string>(AuthTokenKey)).Value;
            _logger.LogInformation($"JwtToken: {token}");

            if (token is null)
                return new(Anonymous);

            JwtSecurityTokenHandler handler = new();
            var jwt = handler.ReadJwtToken(token);
            var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, JwtBearerDefaults.AuthenticationScheme)));
            _logger.LogInformation($"State {state.User.Identity.IsAuthenticated}");
            return state;
        }
        catch
        {
            return new(Anonymous);
        }



    }

    public ClaimsPrincipal GetClaims(string token)
    {
        JwtSecurityTokenHandler handler = new();
        var jwt = handler.ReadJwtToken(token);
        var claims = new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, JwtBearerDefaults.AuthenticationScheme));
        return claims;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>True if login is success, otherwise false</returns>
    public async Task<bool> Login(string email, string password)
    {
        var response = await _sender.Send(new LoginFeature.Request(email, password));
        if (response is not null)
        {
            await _localStorage.SetAsync(AuthTokenKey, response.JwtToken);
            // await httpContextAccessor.HttpContext.AuthenticateAsync();
            /* await httpContextAccessor.HttpContext?.SignInAsync(
                // scheme: JwtBearerDefaults.AuthenticationScheme,
                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                GetClaims(response.JwtToken)
            ); */
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return true;
        }


        return false;
    }
}
