using AutoMapper;
using DomraSinForms.Domain.Models;
using DomraSinForms.Persistence;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DomraSinForms.Application.Forms.Commands.Update
{
    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, Form>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UpdateFormCommand> _logger;

        public UpdateFormCommandHandler(ApplicationDbContext context, ILogger<UpdateFormCommand> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Form> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Start handling of {nameof(UpdateFormCommand)}");
            var form = await _context.Forms
                .Include(f => f.Questions)
                .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (form is null)
                return null;

            form.Title = request.Title;
            form.Description = request.Description;
            _context.Update(form);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogWarning($"Finish handling of {nameof(UpdateFormCommand)}");
            return form;
        }
    }
}
