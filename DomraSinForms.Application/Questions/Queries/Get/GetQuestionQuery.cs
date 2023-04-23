using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Queries.Get;
public class GetQuestionQuery : IGetSingleRequest<QuestionBase>
{
    public string Id { get; set; }
}
