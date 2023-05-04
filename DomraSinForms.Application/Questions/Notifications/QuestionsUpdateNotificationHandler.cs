using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Notifications;
public class QuestionsUpdateNotificationHandler : INotificationHandler<QuestionsUpdateNotification>
{
    private readonly ApplicationDbContext _context;

    public QuestionsUpdateNotificationHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(QuestionsUpdateNotification notification, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .Include(f => f.Questions)
            .FirstOrDefaultAsync(f => f.Id == notification.FormId, cancellationToken);

        if (form is null)
            return;

        form.Questions = new(
            form.Questions.OrderBy(q => q.Index).Select((question, i) =>
            {
                question.Index = i + 1;
                return question;
            }));
        form.LastUpdateDate = DateTime.UtcNow;
        _context.Update(form);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
