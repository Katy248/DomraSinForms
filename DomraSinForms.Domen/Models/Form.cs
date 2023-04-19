using System.ComponentModel.DataAnnotations;
using DomraSinForms.Domen.Models.Questions;

namespace DomraSinForms.Domen.Models;

public class Form : DbEntity
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string CreatorId { get; set; }
    public List<QuestionBlock> Questions { get; set; } = new();
    public List<FormAnswers> FormAnswers { get; set; } = new();
    
}
