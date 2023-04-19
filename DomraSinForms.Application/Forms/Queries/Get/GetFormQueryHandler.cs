using DomraSinForms.Domen.Models;
using Forms.Mvc.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Queries.Get;

public class GetFormQueryHandler : IRequestHandler<GetFormQuery, Form>
{
    private readonly ApplicationDbContext _context;

    public GetFormQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Form> Handle(GetFormQuery request, CancellationToken cancellationToken)
    {
        return await _context.Forms.Include(f => f.Questions).FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
    }
}
