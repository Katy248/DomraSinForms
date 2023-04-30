using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models;
using MediatR;
using DomraSinForms.Persistence;

namespace DomraSinForms.Application.Forms.Queries.GetList
{
    public class GetFormListQueryHandler : IRequestHandler<GetFormListQuery, FormsDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFormListQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FormsDto> Handle(GetFormListQuery request, CancellationToken cancellationToken)
        {
            var result = new FormsDto
            {
                Count = request.Count,
                Page = request.Page,
                SearchText = request.SearchText,
            };

            var forms = _context.Forms
                .Where(f => f.Title.Contains(request.SearchText) | f.Description.Contains(request.SearchText))
                .Skip(request.Page * request.Count)
                .Take(request.Count);
            result.Forms = _mapper.ProjectTo<FormDto>(forms).ToArray();

            result.PageCount = (int)Math.Round(
                (double)_context.Forms.Where(f => f.Title.Contains(request.SearchText) | f.Description.Contains(request.SearchText)).Count() 
                / (double)request.Count, MidpointRounding.ToPositiveInfinity);

            return result;
        }
    }
}
