using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DomraSinForms.Application.Questions.Commands.Update;
public class UpdateOptionsCommandValidator : AbstractValidator<UpdateOptionsCommand>
{
    public UpdateOptionsCommandValidator()
    {
        RuleFor(c => c.Options)
            .NotEmpty();
    }
}
