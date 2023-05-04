using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DomraSinForms.Application.Forms.Commands.Create;
public class CreateFormCommandValidator : AbstractValidator<CreateFormCommand>
{
    public CreateFormCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.CreatorId).NotEmpty();
    }
}
