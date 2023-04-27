using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models;
using MediatR;
using DomraSinForms.Persistence;

namespace DomraSinForms.Application.Forms.Queries.GetList
{
    public class GetFormListQueryHandler : IRequestHandler<GetFormListQuery, IEnumerable<IMapWith<Form>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFormListQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IMapWith<Form>>> Handle(GetFormListQuery request, CancellationToken cancellationToken)
        {
            var forms = _context.Forms
                .Where(f => f.Title.Contains(request.SearchText) | f.Description.Contains(request.SearchText))
                .Skip(request.Page * request.Count)
                .Take(request.Count);
            return _mapper.ProjectTo<FormDto>(forms).ToArray();
        }
    }
}
