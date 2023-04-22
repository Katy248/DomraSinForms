using DomraSinForms.Application.Interfaces;

namespace DomraSinForms.Application.Forms.Commands.Delete
{
    public class DeleteFormCommand : IDeleteRequest
    {
        public string Id { get; set; }
    }
}
