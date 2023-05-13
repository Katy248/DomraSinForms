using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Statistics;

public class QuestionSummary
{
    public QuestionBase Question { get; set; }
    public IEnumerable<string> Answsers { get; set; }
}
