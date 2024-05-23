using System.IdentityModel.Tokens.Jwt;
using DomraSinForms.Application.Extensions;
using DomraSinForms.Application.Services.Authentication;
using DomraSinForms.Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.JsonWebTokens;

namespace DomraSinForms.Application.Features.Users.Login;
internal class RequestHandler : IRequestHandler<Request, Response?>
{
    private readonly IEnumerable<IValidator<Request>> _validators;
    private readonly IUsersRepository _usersRepository;
    private readonly PasswordService _passwordService;
    private readonly JwtAuthenticationService _jwtAuthenticationService;

    public RequestHandler(
        IEnumerable<IValidator<Request>> validators,
        IUsersRepository usersRepository,
        PasswordService passwordService,
        JwtAuthenticationService jwtAuthenticationService)
    {
        _validators = validators;
        _usersRepository = usersRepository;
        _passwordService = passwordService;
        _jwtAuthenticationService = jwtAuthenticationService;
    }
    public async Task<Response?> Handle(Request request, CancellationToken cancellationToken)
    {
        if (!await _validators.ValidateMany(request, cancellationToken))
            return null;

        if (!await _usersRepository.UserExists(request.Email, cancellationToken))
            return null;

        var user = await _usersRepository.GetByEmail(request.Email, cancellationToken);

        if (!_passwordService.Compare(user.PasswordHash, request.Password))
            return null;

        var handler = new JwtSecurityTokenHandler();

        var jwtToken = handler.WriteToken(_jwtAuthenticationService.GetToken(user));

        return new Response(jwtToken);
    }
}
