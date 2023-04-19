using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domen.Models.Questions;

namespace DomraSinForms.Domen.Models.Answers;

public abstract class AnswerBase : DbEntity
{
    public virtual string Value { get; set; }
}

public class AnswerBase<TQuestion> : AnswerBase 
    where TQuestion : QuestionBase, new() 
{
    public TQuestion Question { get; set; }
}
