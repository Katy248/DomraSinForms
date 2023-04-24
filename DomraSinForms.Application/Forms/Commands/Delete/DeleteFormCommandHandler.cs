using DomraSinForms.Persistence;
using MediatR;

namespace DomraSinForms.Application.Forms.Commands.Delete;

public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteFormCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms.FindAsync(request.Id, cancellationToken);
        if (form == null)
        {
            return false;
        }
        _context.Forms.Remove(form);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
