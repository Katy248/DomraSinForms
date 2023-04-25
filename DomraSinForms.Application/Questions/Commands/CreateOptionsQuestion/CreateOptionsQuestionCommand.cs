using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
public class CreateOptionsQuestionCommand : CreateQuestionBaseCommand<OptionsQuestion>
{
    public ICollection<QuestionOption> Options { get; set; }
    public bool AllowMultipleChoice { get; set; }
}
