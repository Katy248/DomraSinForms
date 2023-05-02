using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Answers.AnswersModels;

public class RadioAnswer : AnswerViewModel
{
    public RadioAnswer() : base() { }
    public RadioAnswer(OptionsQuestion question) : base(question)
    {
        if (question.AllowMultipleChoice)
            return;
    }
    public override string Value 
    { 
        get
        {
            return "";
        }
    }
}
