using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DomraSinForms.Application.Features.Users.Register;
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .MaximumLength(256);
        RuleFor(r => r.Username)
            .NotEmpty();
        RuleFor(r => r.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}
