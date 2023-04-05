using System.ComponentModel.DataAnnotations;

namespace DomraSinForms.Domen.Models;

public class Form : DbEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
    public List<FormBlock> Blocks { get; set; } = new();
}
