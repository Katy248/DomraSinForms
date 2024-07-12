using DomraSinForms.Domain.Contracts;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Queries.Get;
public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionBase?>
{
    private readonly IDatabaseContext _context;

    public GetQuestionQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task<QuestionBase?> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
    {
        var questionBase = await _context.Questions.FindAsync(request.Id, cancellationToken);
        switch (questionBase)
        {
            case TextQuestion:
                return await _context.TextQuestions.FirstOrDefaultAsync(q => q.Id == request.Id);
            case OptionsQuestion:
                return await _context.OptionsQuestions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == request.Id);
        }

        return null;
    }
}
