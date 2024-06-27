using DomraSinForms.Domain.Models.Answers;

namespace DomraSinForms.Domain.Models.Questions;

#nullable disable

public abstract class QuestionBase : DbEntity
{
    public string QuestionText { get; set; }
    public int Index { get; set; }
    public string FormId { get; set; }
    public bool IsRequired { get; set; }
    public ICollection<Answer> Answers { get; set; }
}
