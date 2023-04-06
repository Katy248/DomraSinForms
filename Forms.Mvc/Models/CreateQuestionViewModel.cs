using DomraSinForms.Domen.Models;
using Microsoft.Build.Framework;

namespace Forms.Mvc.Models;

public class CreateQuestionViewModel
{
    [Required]
    public string FormId { get; set; }
    public Question Question { get; set; }
}
