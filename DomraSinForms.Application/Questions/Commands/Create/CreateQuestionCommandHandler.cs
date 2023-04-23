using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Questions;
using Forms.Mvc.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Commands.Create;
public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionBase>
{
    private readonly ApplicationDbContext _context;

    public CreateQuestionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<QuestionBase> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms.FirstOrDefaultAsync(f => f.Id == request.FormId, cancellationToken);
        if (form == null) 
            return QuestionNone.Instance;

        form.Questions.Add(request.Question);

        _context.Update(form);
        await _context.SaveChangesAsync(cancellationToken);

        return await _context.Questions.FindAsync(request.Question.Id);
    }
}
