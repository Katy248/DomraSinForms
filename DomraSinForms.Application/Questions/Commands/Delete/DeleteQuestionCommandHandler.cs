using DomraSinForms.Application.Questions.Notifications;
using DomraSinForms.Domain.Models;
using DomraSinForms.Persistence;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands.Delete;
public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteQuestionCommandHandler(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions.FindAsync(request.Id, cancellationToken);

        if (question is null)
            return false;
        
        _context.Questions.Remove(question);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new QuestionsUpdateNotification { FormId = question.FormId }, cancellationToken);

        return true;
    }
}
