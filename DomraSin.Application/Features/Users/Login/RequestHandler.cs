using System.IdentityModel.Tokens.Jwt;
using DomraSin.Application.Extensions;
using DomraSin.Application.Services.Authentication;
using DomraSin.Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.JsonWebTokens;

namespace DomraSin.Application.Features.Users.Login;
internal class RequestHandler : IRequestHandler<Request, Response>
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
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        if (!await _validators.ValidateMany(request, cancellationToken))
            return Response.Failed;

        if (!await _usersRepository.UserExists(request.Email, cancellationToken))
            return Response.Failed;

        var user = await _usersRepository.GetByEmail(request.Email, cancellationToken);

        if (!_passwordService.Compare(user.PasswordHash, request.Password))
            return Response.Failed;

        var handler = new JwtSecurityTokenHandler();
        
        var jwtToken = handler.WriteToken(_jwtAuthenticationService.GetToken(user));

        return new Response(true, jwtToken);
    }
}
