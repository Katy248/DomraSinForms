using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Answers.AnswersModels;

public class StringAnswer : AnswerViewModel
{
    public StringAnswer(TextQuestion question) : base(question)
    {
    }
    public StringAnswer() : base()
    {
        
    }
    public string Answer { get; set; }
    public override string Value => Answer; 
}
