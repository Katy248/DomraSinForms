using AutoMapper;
using Forms.Mvc.Data;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Queries.GetList
{
    public class GetFormListQueryHandler : IRequestHandler<GetFormListQuery, IEnumerable<FormDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFormListQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FormDto>> Handle(GetFormListQuery request, CancellationToken cancellationToken)
        {
            var forms = _context.Forms
                .Where(f => f.Title.Contains(request.SearchText)|f.Description.Contains(request.SearchText))
                .Skip(request.Page * request.Count)
                .Take(request.Count);
            return _mapper.ProjectTo<FormDto>(forms).ToArray();
        }
    }
}
