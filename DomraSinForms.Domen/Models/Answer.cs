using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DomraSinForms.Domen.Models;

[Table("Answers")]
public class Answer : DbEntity
{
    public string Value { get; set; }
    [NotMapped]
    public Question Question { get; set; }
    public string QuestionText { get; set; }
}
