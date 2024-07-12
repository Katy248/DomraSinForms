using DomraSinForms.Domain.Contracts;
using DomraSinForms.Domain.Models.Answers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Answers.Commands.Update;
public class UpdateFormAnswersCommandHandler : IRequestHandler<UpdateFormAnswersCommand, FormAnswers?>
{
    private readonly IDatabaseContext _context;

    public UpdateFormAnswersCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task<FormAnswers?> Handle(UpdateFormAnswersCommand request, CancellationToken cancellationToken)
    {
        if (request.Answer is null)
            return null;

        var formAnswers = await _context.FormAnswers
            .Include(f => f.Answers)
            .FirstOrDefaultAsync(f => f.FormId == request.FormId && f.UserId == request.UserId && !f.IsCompleted, cancellationToken);
        if (formAnswers is null)
            return null;

        if (formAnswers.IsCompleted)
            return formAnswers;

        var answer = formAnswers.Answers.FirstOrDefault(a => a.QuestionId == request.Answer.QuestionId);
        if (answer is null)
            formAnswers.Answers.Add(request.Answer);
        else
            answer.Value = request.Answer.Value;

        _context.FormAnswers.Update(formAnswers);
        await _context.SaveChangesAsync(cancellationToken);

        return formAnswers;
    }
}
