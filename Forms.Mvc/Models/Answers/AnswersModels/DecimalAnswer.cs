using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Answers.AnswersModels;

public class DecimalAnswer : AnswerViewModel
{
    public DecimalAnswer() : base() { }

    public DecimalAnswer(TextQuestion question) : base(question)
    {
        
    }
    public decimal Number { get; set; }
    public override string Value => Number.ToString();
}
