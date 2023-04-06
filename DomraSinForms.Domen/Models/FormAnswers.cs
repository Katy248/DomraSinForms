using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Domen.Models;
[Table("FormAnswers")]
public class FormAnswers : DbEntity
{
    public List<Answer> Answers { get; set; }
}
