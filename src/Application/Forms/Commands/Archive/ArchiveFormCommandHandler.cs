using DomraSinForms.Domain.Contracts;
using DomraSinForms.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Forms.Commands.Archive;
public class ArchiveFormCommandHandler : IRequestHandler<ArchiveFormCommand, Form?>
{
    private readonly IDatabaseContext _context;

    public ArchiveFormCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task<Form?> Handle(ArchiveFormCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

        if (form is null)
            return null;

        form.IsInArchive = true;

        _context.Forms.Update(form);
        await _context.SaveChangesAsync(cancellationToken);

        return form;
    }
}
