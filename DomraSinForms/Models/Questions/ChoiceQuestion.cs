using DomraSinForms.Models.Answers;

namespace DomraSinForms.Models.Questions;

public class ChoiceQuestion : Question
{
    public List<ChoiceOption> Options { get; set; }
    public bool IsRadio { get; set; }
}