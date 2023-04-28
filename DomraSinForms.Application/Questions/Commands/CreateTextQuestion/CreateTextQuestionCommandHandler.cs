using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Commands.CreateTextQuestion;
public class CreateTextQuestionCommandHandler : IRequestHandler<CreateTextQuestionCommand, TextQuestion>
{
    private readonly ApplicationDbContext _context;

    public CreateTextQuestionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<TextQuestion> Handle(CreateTextQuestionCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .Include(x => x.Questions)
            .FirstOrDefaultAsync(f => f.Id == request.FormId, cancellationToken);

        if (form is null)
            return null;

        var question = new TextQuestion
        {
            QuestionText = request.QuestionText,
            Type = request.Type,
            Index = form.Questions.Count + 1,
            IsRequired = request.IsRequired,
        };

        form.Questions.Add(question);

        form.Questions.OrderBy(q => q.Index).Select((question, i) =>
        {
            question.Index = i;
            return question;
        });

        _context.Update(form);
        await _context.SaveChangesAsync(cancellationToken);

        return question;
    }
}
