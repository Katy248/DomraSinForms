using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public partial class PhoneNumberAnswer : AnswerViewModel
{
    public PhoneNumberAnswer() : base()
    {
    }

    public PhoneNumberAnswer(TextQuestion question, Answer answer) : base(question, answer)
    {
    }
    private string? _value;
    [RegularExpression("[\\+\\(\\)\\-\\d]+")]
    [Required(AllowEmptyStrings = false)]
    public override string Value
    {
        get => _value ?? "";
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                return;
            if (PhoneNumberRegex().IsMatch(value))
                _value = value;
        }
    }

    [GeneratedRegex(@"[\+\(\)\-\d]+")]
    private static partial Regex PhoneNumberRegex();
}
