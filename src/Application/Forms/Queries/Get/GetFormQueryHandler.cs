using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Contracts;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Forms.Queries.Get;

public class GetFormQueryHandler : IRequestHandler<GetFormQuery, Form?>
{
    private readonly IDatabaseContext _context;
    private readonly IMediator _mediator;

    public GetFormQueryHandler(IDatabaseContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task<Form?> Handle(GetFormQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .AsNoTracking()
            /*  .Where(f => f.CreatorId == request.UserId)*/
            .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

        if (form is null)
            return null;

        form.Questions = new List<QuestionBase>(await _mediator.Send(new GetQuestionListQuery { FormId = form.Id, }));

        return form;
    }
}
