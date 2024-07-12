﻿using DomraSinForms.Application.Forms.Notifications.Update;
using DomraSinForms.Domain.Contracts;
using DomraSinForms.Domain.Models;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DomraSinForms.Application.Forms.Commands.Update
{
    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, Form?>
    {
        private readonly IDatabaseContext _context;
        private readonly IMediator _mediator;
        private readonly ILogger<UpdateFormCommand> _logger;

        public UpdateFormCommandHandler(IDatabaseContext context, IMediator mediator, ILogger<UpdateFormCommand> logger)
        {
            _context = context;
            _mediator = mediator;
            _logger = logger;
        }
        public async Task<Form?> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Start handling of {nameof(UpdateFormCommand)}");
            var form = await _context.Forms
                .Include(f => f.Questions)
                .Where(f => f.CreatorId == request.UserId)
                .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (form is null || form.IsInArchive)
                return null;

            form.Title = request.Title;
            form.Description = request.Description;
            form.LastUpdateDate = DateTime.UtcNow;

            _context.Forms.Update(form);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UpdateFormNotification { FormId = request.Id }, cancellationToken);

            return form;
        }
    }
}
