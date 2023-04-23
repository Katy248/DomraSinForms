using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Domain.Models.Questions;
public class OptionsQuestion : QuestionBase
{
    public ICollection<QuestionOption> Options { get; set; }

    public bool AllowMultipleChoice { get; set; }
}
