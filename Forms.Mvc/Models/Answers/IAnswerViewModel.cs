using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Answers;

public interface IAnswerViewModel
{
    public string QuestionId { get; set; }
    public string FormId { get; set; }
    public int Index { get; set; }
    public bool IsRequired { get; set; }
    public string Value { get; }
    public QuestionBase? Question { get; set; }
}
