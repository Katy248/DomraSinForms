using DomraSinForms.Application.Forms.Commands.Update;
using DomraSinForms.Domain.Models;

namespace Forms.Mvc.Models
{
    public class EditFormViewModel
    {
        public Form? Form{ get; set; }
        public UpdateFormCommand UpdateFormCommand { get; set; }

    }
}
