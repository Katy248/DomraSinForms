using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Queries.GetList;
public class GetQuestionListQuery : IGetListRequest<QuestionBase>
{
    public int Page { get => 0; set { } } 
    public int Count { get => int.MaxValue; set { } }
    public string SearchText { get => ""; set { } }
    public string FormId { get; set; }
}
