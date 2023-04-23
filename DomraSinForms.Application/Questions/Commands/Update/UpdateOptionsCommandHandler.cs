using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Questions;
using Forms.Mvc.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Commands.Update;
internal class UpdateOptionsCommandHandler : IRequestHandler<UpdateOptionsCommand, OptionsQuestion>
{
    private readonly ApplicationDbContext _context;

    public UpdateOptionsCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<OptionsQuestion> Handle(UpdateOptionsCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.OptionsQuestions
            .Include(q => q.Options)
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

        if (question is null)
            return null;

        question.Options = request.Options;

        _context.Update(question);
        await _context.SaveChangesAsync(cancellationToken);
        
        return question;
    }
}
