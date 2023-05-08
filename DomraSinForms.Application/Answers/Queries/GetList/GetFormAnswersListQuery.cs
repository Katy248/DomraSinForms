using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Answers;
using MediatR;

namespace DomraSinForms.Application.Answers.Queries.GetList;
public class GetFormAnswersListQuery : IRequest<IEnumerable< FormAnswersDto>>
{
    public int Page { get => 0; set { } }
    public int Count { get => int.MaxValue; set { } }
    public string SearchText { get; set; } = "";
    public string FormId { get; set; }
}
