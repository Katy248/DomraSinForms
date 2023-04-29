using DomraSinForms.Application.Forms.Commands.Update;
using DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
using DomraSinForms.Application.Questions.Commands.CreateTextQuestion;
using DomraSinForms.Application.Questions.Commands.UpdateOptionsQuestion;
using DomraSinForms.Application.Questions.Commands.UpdateTextQuestion;
using DomraSinForms.Domain.Models;

namespace Forms.Mvc.Models
{
    public class EditFormViewModel
    {
        public Form? Form{ get; set; }
        public UpdateFormCommand UpdateFormCommand { get; set; }
        public CreateTextQuestionCommand CreateTextQuestionCommand { get; set; }
        public CreateOptionsQuestionCommand CreateOptionsQuestionCommand { get; set; }
        public UpdateTextQuestionCommand UpdateTextQuestionCommand { get; set; }
        public UpdateOptionsQuestionCommand UpdateOptionsQuestionCommand { get; set; }
    }
}
