using DomraSinForms.Domen.Models.Answers;

namespace DomraSinForms.Domen.Models.Questions;

public class ChoiceQuestion : Question
{
    public List<ChoiceOption> Options { get; set; }
    public bool IsRadio { get; set; }
}