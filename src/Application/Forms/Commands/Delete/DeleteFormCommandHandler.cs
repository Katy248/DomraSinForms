using DomraSinForms.Domain.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Forms.Commands.Delete;

public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, bool>
{
    private readonly IDatabaseContext _context;

    public DeleteFormCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms.FirstOrDefaultAsync(f => f.Id == request.Id && f.CreatorId == request.UserId, cancellationToken);
        if (form == null)
            return false;

        var versions = await _context.FormVersions.Where(fv => fv.FormId == form.Id).ToArrayAsync(cancellationToken);

        _context.FormVersions.RemoveRange(versions);
        _context.Forms.Remove(form);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
