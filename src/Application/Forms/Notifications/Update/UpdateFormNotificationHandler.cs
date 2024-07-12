using DomraSinForms.Domain.Contracts;
using DomraSinForms.Domain.Models.Versions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Forms.Notifications.Update;
public class UpdateFormNotificationHandler : INotificationHandler<UpdateFormNotification>
{
    private readonly IDatabaseContext _context;

    public UpdateFormNotificationHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateFormNotification notification, CancellationToken cancellationToken)
    {
        var uncompletedAnswers = await _context.FormAnswers.Where(fa => fa.FormId == notification.FormId && !fa.IsCompleted).ToArrayAsync();
        _context.FormAnswers.RemoveRange(uncompletedAnswers);

        var form = await _context.Forms
            .Include(f => f.Version)
            .FirstAsync(f => f.Id == notification.FormId, cancellationToken);

        form.Version = new FormVersion { FormId = form.Id, CreationDate = DateTime.UtcNow, Index = form.Version?.Index + 1 ?? 1 };
        _context.Forms.Update(form);


        await _context.SaveChangesAsync(cancellationToken);
    }
}
