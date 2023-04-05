using DomraSinForms.Domen.Models.Answers;

namespace DomraSinForms.Domen.Models.Questions;

public abstract class Question : DbEntity
{
    public bool IsRequired { get; set; }
    //public abstract QuestionResult Parse(Answer answer);
}