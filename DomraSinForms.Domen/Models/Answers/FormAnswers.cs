using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Domen.Models.Answers;
public class FormAnswers : DbEntity
{
    public Form Form { get; set; } = new();
    public List<Answer> Answers { get; set; } = new();
}
