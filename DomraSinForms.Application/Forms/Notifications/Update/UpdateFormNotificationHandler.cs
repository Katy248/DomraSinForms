using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Forms.Notifications.Update;
public class UpdateFormNotificationHandler : INotificationHandler<UpdateFormNotification>
{
    private readonly ApplicationDbContext _context;

    public UpdateFormNotificationHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateFormNotification notification, CancellationToken cancellationToken)
    {
        var uncompletedAnswers = await _context.FormAnswers.Where(fa => fa.FormId == notification.FormId && !fa.IsCompleted).ToArrayAsync();

        _context.FormAnswers.RemoveRange(uncompletedAnswers);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
