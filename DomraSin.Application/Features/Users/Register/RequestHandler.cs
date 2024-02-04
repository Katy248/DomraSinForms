using System.IO;
using DomraSin.Application.Extensions;
using DomraSin.Application.Services.Authentication;
using DomraSin.Domain.Interfaces.Repositories;
using DomraSin.Domain.Models;
using FluentValidation;
using MediatR;

namespace DomraSin.Application.Features.Users.Register;
internal class RequestHandler(
    IEnumerable<IValidator<Request>> validators,
    IUsersRepository usersRepository,
    PasswordService passwordService) : IRequestHandler<Request, Response>
{
    private readonly IEnumerable<IValidator<Request>> _validators = validators;
    private readonly IUsersRepository _usersRepository = usersRepository;
    private readonly PasswordService _passwordService = passwordService;

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        if (!await _validators.ValidateMany(request, cancellationToken))
            return Response.Failure();

        if (await _usersRepository.UserExists(request.Email, cancellationToken))
            return Response.Failure();

        var user = new User 
        { 
            Email = request.Email,
            Name = request.Username,
            PasswordHash = _passwordService.GetHash(request.Password),
            Verified = false,
        };
        
        var insertResult = await _usersRepository.Insert(user, cancellationToken);

        // TODO: Add verification calls

        return new Response(insertResult);
    }
}
