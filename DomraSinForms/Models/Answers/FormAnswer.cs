namespace DomraSinForms.Models.Answers;

public class FormAnswer : DbEntity
{
    public string CreatorId { get; set; }
    public Form Form { get; set; }
    public List<FormBlockAnswer> FormBlockAnswers { get; set; }
}
