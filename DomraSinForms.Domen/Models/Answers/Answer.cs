using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domen.Models.Questions;

namespace DomraSinForms.Domen.Models.Answers;

public abstract class Answer : DbEntity
{
    public QuestionBase Question { get; set; }
    public virtual string Value { get; set; }
}
