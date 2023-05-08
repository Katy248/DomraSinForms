using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;

namespace Forms.Mvc.Models.Statistics
{
    public class FormAnswersListViewModel
    {
    /*    public FormAnswers FormAnswers { get; set; }*/
        public IEnumerable<FormAnswersDto> AnswersDto { get; set; }
        public Form Form { get; set; }
        public GetFormAnswersListQuery GetFormAnswersListQuery { get; set;}
    }
}
