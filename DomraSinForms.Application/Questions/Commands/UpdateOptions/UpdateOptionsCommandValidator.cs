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
