using System.ComponentModel.DataAnnotations.Schema;

namespace DomraSinForms.Domen.Models;

[Table("Answers")]

public class Answer : DbEntity
{
    public string Value { get; set; }
}
