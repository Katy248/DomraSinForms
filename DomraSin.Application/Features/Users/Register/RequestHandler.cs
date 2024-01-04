using DomraSin.Application.Extensions;
using FluentValidation;
using MediatR;

namespace DomraSin.Application.Features.Users.Register;
internal class RequestHandler(
    IEnumerable<IValidator<Request>> validators) : IRequestHandler<Request, Response>
{
    private readonly IEnumerable<IValidator<Request>> _validators = validators;

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        if (!await _validators.ValidateMany(request, cancellationToken))
            return new Response(false);
        
        return new Response(false);
    }
}
