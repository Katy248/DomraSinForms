using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.ChartsWrapper.Models;
public interface IQuestionSummary
{
    QuestionBase Question { get; set; }
    IEnumerable<string> Answsers { get; set; }
}
