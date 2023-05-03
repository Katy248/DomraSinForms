using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Answers.Commands.Create;
public class CreateFormAnswersCommandHandler : IRequestHandler<CreateFormAnswersCommand, FormAnswers>
{
    private readonly ApplicationDbContext _context;

    public CreateFormAnswersCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<FormAnswers> Handle(CreateFormAnswersCommand request, CancellationToken cancellationToken)
    {
        var formAnswers = await _context.FormAnswers
            .Include(x => x.Answers)
            .FirstOrDefaultAsync(fa => fa.UserId == request.UserId && fa.FormId == request.FormId && !fa.IsCompleted, cancellationToken);

        if (formAnswers is null)
            return null;

        if (formAnswers.IsCompleted)
            return formAnswers;

        var form = await _context.Forms
            .Include(x => x.Questions)
            .FirstOrDefaultAsync(fa => fa.Id == formAnswers.FormId);

        if (form is null)
            return null;

        foreach (var question in form.Questions)
        {
            var answer = formAnswers.Answers.FirstOrDefault(q => q.QuestionId == question.Id);
            if (answer is not null)
            {
                if (question.IsRequired && string.IsNullOrWhiteSpace(answer.Value))
                    return null;
            }
            else
                return null;
        }

        formAnswers.IsCompleted = true;

        _context.Update(formAnswers);
        await _context.SaveChangesAsync();

        return formAnswers;
        
        
        
        /*var form = await _context.Forms.FindAsync(request.FormId, cancellationToken);

        if (form is null)
            return null;

        var answers = new FormAnswers
        {
            FormId = request.FormId,
            Answers = request.Answers.ToList(),
        };

        await _context.AddAsync(answers, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return answers;*/
    }
}
