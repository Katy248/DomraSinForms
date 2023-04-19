using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Domen.Models.Answers;
public class AnswerBlock : DbEntity
{
    public NumberAnswer? NumberAnswer { get; set; }
    public TextAnswer? TextAnswer { get; set; }
    public AnswerBase Answer 
    { 
        get
        {
            return Answer ?? TextAnswer ?? null;
        }
    }
}
