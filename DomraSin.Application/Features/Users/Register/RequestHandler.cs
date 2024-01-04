using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSin.Application.Extensions;
using FluentValidation;
using MediatR;

namespace DomraSin.Application.Features.Users.Register;
public class RequestHandler(
    IEnumerable<IValidator<Request>> validators) : IRequestHandler<Request>
    
{
    private readonly IEnumerable<IValidator<Request>> _validators = validators;

    public async Task Handle(Request request, CancellationToken cancellationToken)
    {
        if (!await _validators.ValidateMany(request, cancellationToken))
            return;
    }
}
