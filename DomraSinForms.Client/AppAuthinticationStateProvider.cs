using Microsoft.AspNetCore.Components.Authorization;

namespace DomraSinForms.Client;

public class AppAuthinticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}