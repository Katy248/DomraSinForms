using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Answers.AnswersModels;

public class RadioAnswer : AnswerViewModel
{
    public RadioAnswer() : base() { }
    public RadioAnswer(OptionsQuestion question) : base(question)
    {
        if (question.AllowMultipleChoice)
            return;
        foreach (var option in question.Options)
        {
            Options.Add(option.Text);
        }
    }
    public List<string> Options { get; set; } = new();
    public string SelectedValue { get; set; }
    public override string Value 
    {
        get => SelectedValue;
    }
}
