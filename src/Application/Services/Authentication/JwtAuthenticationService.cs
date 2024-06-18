using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DomraSinForms.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DomraSinForms.Application.Services.Authentication;
public class JwtAuthenticationService
{
    protected readonly IConfiguration _configuration;

    public JwtAuthenticationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private static IEnumerable<Claim> GetClaims(User user)
    {
        yield return new Claim(ClaimTypes.NameIdentifier, user.Id.Value.ToString());
        yield return new Claim(ClaimTypes.Name, user.Name);
        yield return new Claim(ClaimTypes.Email, user.Email);
    }
    public JwtSecurityToken GetToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetRequiredSection("Jwt:SecurityKey").Get<string>() ?? ""));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var claims = GetClaims(user);
        var token = tokenHandler.CreateJwtSecurityToken(
            issuer: string.Join(';', _configuration.GetSection("Jwt:Issuers")?.Get<IEnumerable<string>>() ?? Array.Empty<string>()),
            audience: string.Join(';', _configuration.GetSection("Jwt:Audiences")?.Get<IEnumerable<string>>() ?? Array.Empty<string>()),
            subject: new ClaimsIdentity(claims),
            expires: DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:ExpiryInDays")?.Get<int>() ?? 1),
            signingCredentials: credentials);

        return token;
    }
}
