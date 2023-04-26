using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Answers;
using Forms.Mvc.Data;
using MediatR;

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
        var form = await _context.Forms.FindAsync(request.FormId, cancellationToken);

        if (form is null)
            return null;

        var answers = new FormAnswers
        {
            FormId = request.FormId,
            Answers = request.Answers.ToList(),
        };

        await _context.AddAsync(answers, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return answers;
    }
}
