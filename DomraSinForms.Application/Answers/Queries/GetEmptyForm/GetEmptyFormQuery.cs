using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Answers.Commands.Create;
using MediatR;

namespace DomraSinForms.Application.Answers.Queries.GetEmptyForm;
public class GetEmptyFormQuery : IRequest<CreateFormAnswersCommand>
{
    public string FormId { get; set; }
    public string UserId { get; set; }
}
