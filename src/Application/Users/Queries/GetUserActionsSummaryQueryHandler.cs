using DomraSinForms.Domain.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Users.Queries;
public class GetUserActionsSummaryQueryHandler : IRequestHandler<GetUserActionsSummaryQuery, UsersActionsSummary?>
{
    private readonly IDatabaseContext _context;

    public GetUserActionsSummaryQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task<UsersActionsSummary?> Handle(GetUserActionsSummaryQuery request, CancellationToken cancellationToken)
    {
        var result = new UsersActionsSummary
        {
            Forms = await _context.Forms.Where(f => f.CreatorId == request.UserId).ToArrayAsync(),
            FormAnswers = await _context.FormAnswers.Include(fa => fa.Form).Where(f => f.UserId == request.UserId && f.IsCompleted).ToArrayAsync(),
            FormVersions = await _context.FormVersions.Where(f => f.Form.CreatorId == request.UserId).ToArrayAsync()
        };

        return result;
    }
}
