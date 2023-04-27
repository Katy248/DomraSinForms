namespace DomraSinForms.Domain.Models.Questions;
public class OptionsQuestion : QuestionBase
{
    public ICollection<QuestionOption> Options { get; set; }

    public bool AllowMultipleChoice { get; set; }
}
