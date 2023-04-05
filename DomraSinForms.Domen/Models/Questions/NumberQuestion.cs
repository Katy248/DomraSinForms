namespace DomraSinForms.Domen.Models.Questions;

public class NumberQuestion : Question
{
    public decimal Min { get; set; } = decimal.MinValue;
    public decimal Max { get; set; } = decimal.MaxValue;
}