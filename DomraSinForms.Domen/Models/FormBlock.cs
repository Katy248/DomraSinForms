using DomraSinForms.Domen.Models.Questions;

namespace DomraSinForms.Domen.Models;

public class FormBlock : DbEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ChoiceQuestion? ChoiceQuestion { get; set; }
    public StringQuestion? StringQuestion { get; set; }
    public NumberQuestion? NumberQuestion { get; set; }
    public DateQuestion? DateQuestion { get; set; }
    public TimeQuestion? TimeQuestion { get; set; }
}