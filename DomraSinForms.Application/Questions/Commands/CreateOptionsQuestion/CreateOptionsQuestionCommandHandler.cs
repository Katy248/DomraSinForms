using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
public class CreateOptionsQuestionCommandHandler : IRequestHandler<CreateOptionsQuestionCommand, OptionsQuestion>
{
    private readonly ApplicationDbContext _context;

    public CreateOptionsQuestionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<OptionsQuestion> Handle(CreateOptionsQuestionCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .Include(x => x.Questions)
            .FirstOrDefaultAsync(f => f.Id == request.FormId, cancellationToken);

        if (form == null)
            return null;

        var question = new OptionsQuestion
        {
            QuestionText = request.QuestionText,
            AllowMultipleChoice = request.AllowMultipleChoice,
            Options = request.Options,
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
