using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domen.Models.Answers;

namespace DomraSinForms.Domen.Models;
[Table("FormAnswers")]
public class FormAnswers : DbEntity
{
    public Form? Form { get; set; } = new();
    public List<AnswerBlock> Answers { get; set; } = new();
}
