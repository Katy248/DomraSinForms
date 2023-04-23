using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Questions;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands.Create;
public class CreateQuestionCommand : IRequest<QuestionBase>
{
    public string FormId { get; set; }
    public QuestionBase Question { get; set; }
}
