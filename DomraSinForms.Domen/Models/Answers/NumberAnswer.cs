using DomraSinForms.Domen.Models.Questions;

namespace DomraSinForms.Domen.Models.Answers;
public class NumberAnswer : AnswerBase<NumberQuestion>
{
    public int NumberValue { get; set; }
    public override string Value { get => NumberValue.ToString(); }
}
