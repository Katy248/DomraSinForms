﻿using DomraSinForms.Application.Forms.Notifications.Update;
using DomraSinForms.Application.Questions.Notifications;
using DomraSinForms.Domain.Contracts;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Commands.CreateTextQuestion;
public class CreateTextQuestionCommandHandler : IRequestHandler<CreateTextQuestionCommand, TextQuestion?>
{
    private readonly IDatabaseContext _context;
    private readonly IMediator _mediator;

    public CreateTextQuestionCommandHandler(IDatabaseContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task<TextQuestion?> Handle(CreateTextQuestionCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .Include(x => x.Questions)
            .FirstOrDefaultAsync(f => f.Id == request.FormId, cancellationToken);

        if (form is null)
            return null;

        var question = new TextQuestion
        {
            QuestionText = request.QuestionText,
            Type = request.Type,
            Index = form.Questions.Count + 1,
            IsRequired = request.IsRequired,
        };

        form.Questions.Add(question);

        _context.Forms.Update(form);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new QuestionsUpdateNotification { FormId = question.FormId }, cancellationToken);
        await _mediator.Publish(new UpdateFormNotification { FormId = form.Id }, cancellationToken);

        return question;
    }
}
