using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Answers.Queries.GetFormAnswers
{
    public class GetFormAnswersQuery: IGetSingleRequest<FormAnswers>
    {
        public string Id { get; set; }
    }
}
