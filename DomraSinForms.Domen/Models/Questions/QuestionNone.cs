using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Domen.Models.Questions;
public class QuestionNone : QuestionBase
{
    protected QuestionNone()
    {
        
    }
    public static QuestionBase Instance = new QuestionNone();
}
