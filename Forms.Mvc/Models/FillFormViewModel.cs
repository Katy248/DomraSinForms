using DomraSinForms.Application.Answers.Commands.Create;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models;

public class FillFormViewModel
{
    public CreateFormAnswersCommand Command { get; set; }
    public Form Form { get; set; }
}
