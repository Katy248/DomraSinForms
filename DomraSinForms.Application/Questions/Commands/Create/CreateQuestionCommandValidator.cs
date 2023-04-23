using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Questions;
using FluentValidation;

namespace DomraSinForms.Application.Questions.Commands.Create;
public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(c => c.Question)
            .Must(q => 
                (new[] { typeof(TextQuestion), typeof(NumberQuestion), typeof(RadioQuestion), typeof(CheckQuestion) })
                .Contains(q.GetType()));
    }
}
