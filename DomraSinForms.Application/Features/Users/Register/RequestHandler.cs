using System.IO;
using DomraSinForms.Application.Extensions;
using DomraSinForms.Application.Services.Authentication;
using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using FluentValidation;
using MediatR;

namespace DomraSinForms.Application.Features.Users.Register;
internal class RequestHandler : IRequestHandler<Request, Response?>
{
    private readonly IEnumerable<IValidator<Request>> _validators;
    private readonly IUsersRepository _usersRepository;
    private readonly PasswordService _passwordService;

    public RequestHandler(IEnumerable<IValidator<Request>> validators,
        IUsersRepository usersRepository,
        PasswordService passwordService)
    {
        _validators = validators;
        _usersRepository = usersRepository;
        _passwordService = passwordService;
    }

    public async Task<Response?> Handle(Request request, CancellationToken cancellationToken)
    {
        if (!await _validators.ValidateMany(request, cancellationToken))
            return null;

        if (await _usersRepository.UserExists(request.Email, cancellationToken))
            return null;

        var user = User
            .CreateNew(name: request.Username, request.Email, _passwordService.GetHash(request.Password), verified: false);

        var insertResult = await _usersRepository.Insert(user, cancellationToken);

        // TODO: Add verification calls

        return new Response(PrivateUserData.GetFromUser(user));
    }
}
