using DomraSinForms.Domain.Models.Answers;

namespace Forms.Mvc.Models.Answers;

public interface IAnswerViewModelFactory
{
    IEnumerable<IAnswerViewModel> GetAnswers(IEnumerable<Answer> answers);
}