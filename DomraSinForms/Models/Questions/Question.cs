using DomraSinForms.Models.Answers;

namespace DomraSinForms.Models.Questions;

public abstract class Question : DbEntity
{
    public bool IsRequired { get; set; }
    //public abstract QuestionResult Parse(Answer answer);
}