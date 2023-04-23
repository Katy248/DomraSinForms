﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Questions;
using Forms.Mvc.Data;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands.Update;
public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, QuestionBase>
{
    private readonly ApplicationDbContext _context;

    public UpdateQuestionCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<QuestionBase> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions.FindAsync(request.Id, cancellationToken);

        if (question is null) 
            return QuestionNone.Instance;

        question.QuestionText = request.QuestionText;

        _context.Update(question);
        await _context.SaveChangesAsync(cancellationToken);

        return question;
    }
}
