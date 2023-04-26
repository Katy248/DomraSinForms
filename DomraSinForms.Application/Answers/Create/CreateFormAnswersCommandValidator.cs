using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DomraSinForms.Application.Answers.Create;
public class CreateFormAnswersCommandValidator : AbstractValidator<CreateFormAnswersCommand>
{
    public CreateFormAnswersCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.FormId).NotEmpty();
        RuleFor(c => c.Answers).NotEmpty();
    }
}
