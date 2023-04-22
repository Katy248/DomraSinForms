using DomraSinForms.Domen.Models;
using Forms.Mvc.Data;
using MediatR;

namespace DomraSinForms.Application.Forms.Commands.Update
{
    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, Form>
    {
        private readonly ApplicationDbContext _context;

        public UpdateFormCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Form> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            var form = await _context.FindAsync<Form>(request.Id);
            form.Title = request.Title;
            form.Description = request.Description;
            _context.Update(form);
            await _context.SaveChangesAsync(cancellationToken);
            return form;
        }
    }
}
