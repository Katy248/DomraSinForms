using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Answers;

namespace DomraSinForms.Application.Answers.Queries.GetList;
public class GetFormAnswersListQuery : IGetListRequest<FormAnswers>
{
    public int Page { get => 0; set { } }
    public int Count { get => int.MaxValue; set { } }
    public string SearchText { get; set; }
    public string FormId { get; set; }
}
