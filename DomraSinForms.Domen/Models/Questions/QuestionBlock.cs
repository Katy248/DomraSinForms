using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Domen.Models.Questions;
public class QuestionBlock : DbEntity
{
    public NumberQuestion? NumberQuestion { get; set; }
    public TextQuestion? TextQuestion { get; set; }

    public QuestionBase Question
    {
        get
        {
            return NumberQuestion 
                ?? TextQuestion 
                ?? QuestionNone.Instance;
        }
    }
}
