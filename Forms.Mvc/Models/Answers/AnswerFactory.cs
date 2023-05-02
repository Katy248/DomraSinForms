using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using Forms.Mvc.Models.Answers.AnswersModels;

namespace Forms.Mvc.Models.Answers;

public class AnswerFactory : IAnswerViewModelFactory
{
    public IEnumerable<IAnswerViewModel> GetAnswers(IEnumerable<Answer> answers)
    {
        foreach (var answer in answers)
        {
            switch (answer.Question)
            {
                case OptionsQuestion oq:
                    if (oq.AllowMultipleChoice)
                    {
                        yield return new CheckAnswer(oq);
                    }
                    else
                    {
                        yield return new RadioAnswer(oq);
                    }
                    break;
                case TextQuestion tq:
                    switch (tq.Type)
                    {
                        case TextQuestionType.Text:
                            yield return new StringAnswer(tq);
                            break;
                        case TextQuestionType.Number:
                            break;
                        case TextQuestionType.Date:
                            break;
                        case TextQuestionType.Time:
                            break;
                        case TextQuestionType.DateTime:
                            break;
                    }
                    break;
                default:
                    yield break;
            }
        }
    }
}
