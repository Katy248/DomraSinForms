using System.ComponentModel.DataAnnotations;
using DomraSinForms.Domen.Models;
namespace Forms.Mvc.Models;

public class FillFormViewModel
{
    [Required]
    public string FormId { get; set; }
    public string FormTitle { get; set; } = "";
    public string FormDescription { get; set; } = "";
    public List<Answer> Answers { get; set; } = new();

}
