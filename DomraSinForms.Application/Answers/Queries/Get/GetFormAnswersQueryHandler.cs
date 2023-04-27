using DomraSinForms.Domain.Models.Answers;
using Forms.Mvc.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Answers.Queries.Get
{
    public class GetFormAnswersQueryHandler : IRequestHandler<GetFormAnswersQuery, FormAnswers>
    {
        private readonly ApplicationDbContext _context;

        public GetFormAnswersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FormAnswers> Handle(GetFormAnswersQuery request, CancellationToken cancellationToken)
        {
            return await _context.FormAnswers.Include(f => f.Answers).FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
        }
    }
}
