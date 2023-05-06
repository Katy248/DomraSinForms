using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
public class CreateOptionsQuestionCommandValidator : AbstractValidator<CreateOptionsQuestionCommand>
{
    public CreateOptionsQuestionCommandValidator()
    {
        RuleFor(qo => qo.QuestionText).NotEmpty();
        RuleFor(qo => qo.FormId).NotEmpty();
    }
}
