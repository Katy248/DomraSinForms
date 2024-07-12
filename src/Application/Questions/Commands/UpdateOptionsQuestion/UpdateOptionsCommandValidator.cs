﻿using FluentValidation;

namespace DomraSinForms.Application.Questions.Commands.UpdateOptionsQuestion;
public class UpdateOptionsCommandValidator : AbstractValidator<UpdateOptionsQuestionCommand>
{
    public UpdateOptionsCommandValidator()
    {
        RuleFor(c => c.Options)
            .NotEmpty();
    }
}
