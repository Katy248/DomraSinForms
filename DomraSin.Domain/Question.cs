using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSin.Domain;

public class Question : EntityBase
{
    public Form Form { get; set; }
    public string Text { get; set; }
    public IEnumerable<QuestionOption> Options { get; set; }
}

public enum QuestionType
{
    Text, Number, Radio, Check
}
