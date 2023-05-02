using System.Text;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Answers.AnswersModels;

public class CheckAnswer : AnswerViewModel
{
    public CheckAnswer() : base() { }
    public CheckAnswer(OptionsQuestion question) : base(question)
    {
        if (!question.AllowMultipleChoice)
            return;

        var options = new List<(bool, string)>();
        foreach (var option in question.Options)
        {
            options.Add((false, option.Text));
        }
        Options = options;
    }
    public IEnumerable<(bool Check, string Value)> Options { get; set; }

    public override string Value
    {
        get
        {
            var checks = new List<string>();
            foreach (var option in Options)
            {
                if (option.Check)
                    checks.Add(option.Value);
            }
            return string.Join("; ", checks.ToArray());
        }
    }
}
