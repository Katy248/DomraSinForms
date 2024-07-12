using AutoMapper;
using DomraSinForms.Domain.Contracts;
using DomraSinForms.Domain.Models;

using MediatR;

namespace DomraSinForms.Application.Forms.Commands.Create;
public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, Form>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public CreateFormCommandHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Form> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        var form = _mapper.Map<Form>(request);
        form.CreationDate = DateTime.UtcNow;

        await _context.Forms.AddAsync(form, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return form;
    }
}
