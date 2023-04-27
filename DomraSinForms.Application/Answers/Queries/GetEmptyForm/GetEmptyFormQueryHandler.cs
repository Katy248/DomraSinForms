using DomraSinForms.Application.Answers.Commands.Create;
using DomraSinForms.Domain.Models.Answers;
using Forms.Mvc.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Answers.Queries.GetEmptyForm;
public class GetEmptyFormQueryHandler : IRequestHandler<GetEmptyFormQuery, CreateFormAnswersCommand>
{
    private readonly ApplicationDbContext _context;

    public GetEmptyFormQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CreateFormAnswersCommand> Handle(GetEmptyFormQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .Include(f => f.Questions)
            .FirstOrDefaultAsync(f => f.Id == request.FormId, cancellationToken);

        if (form is null)
            return null;

        var command = new CreateFormAnswersCommand
        {
            FormId = form.Id,
            UserId = request.UserId,
        };
        var answers = new List<Answer>(form.Questions.Count);

        foreach (var question in form.Questions)
        {
            answers.Add(new Answer { QuestionId = question.Id });
        }

        command.Answers = answers;

        return command;
    }
}
