namespace DomraSinForms.Models.Answers;

public class FormBlockAnswer : DbEntity
{
    public FormBlock FormBlock { get; set; }
    public Answer Answer { get; set; }
}
