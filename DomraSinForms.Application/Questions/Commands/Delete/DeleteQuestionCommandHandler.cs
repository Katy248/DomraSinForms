using Forms.Mvc.Data;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands.Delete;
public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteQuestionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions.FindAsync(request.Id, cancellationToken);

        if (question is null)
            return false;

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
