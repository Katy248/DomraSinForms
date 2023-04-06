using System.ComponentModel.DataAnnotations;

namespace DomraSinForms.Domen.Models;

public class Form : DbEntity
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string CreatorId { get; set; }
    public List<Question> Questions { get; set; }
    public List<FormAnswers> FormAnswers { get; set; }
}
