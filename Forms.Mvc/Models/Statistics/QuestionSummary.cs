using DomraSinForms.ChartsWrapper.Models;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Statistics;

public class QuestionSummary : IQuestionSummary
{
    public QuestionBase Question { get; set; }
    public IEnumerable<string> Answsers { get; set; }
}
