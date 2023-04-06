using System.ComponentModel.DataAnnotations.Schema;
using DomraSinForms.Domen.Models;

namespace DomraSinForms.Domen.Models;

[Table("Questions")]
public class Question : DbEntity
{
    public string Text { get; set; }
    public bool IsRequired { get; set; }
    //public abstract QuestionResult Parse(Answer answer);
}