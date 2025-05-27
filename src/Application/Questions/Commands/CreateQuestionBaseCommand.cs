using System.ComponentModel.DataAnnotations;
using DomraSinForms.Domain.Models.Questions;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands;

public class CreateQuestionBaseCommand
{
    [Required]
    public string FormId { get; set; } = string.Empty;

    [Required]
    public string QuestionText { get; set; } = string.Empty;
    public bool IsRequired { get; set; } = false;
}

public class CreateQuestionBaseCommand<TQuestion> : CreateQuestionBaseCommand, IRequest<TQuestion>
    where TQuestion : QuestionBase { }
