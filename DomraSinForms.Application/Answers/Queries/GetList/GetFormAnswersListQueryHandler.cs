using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Persistence;
using MediatR;

namespace DomraSinForms.Application.Answers.Queries.GetList;
public class GetFormAnswersListQueryHandler : IRequestHandler<GetFormAnswersListQuery, IEnumerable<IMapWith<FormAnswers>>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFormAnswersListQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<IMapWith<FormAnswers>>> Handle(GetFormAnswersListQuery request, CancellationToken cancellationToken)
    {
        return _mapper.ProjectTo<FormAnswersDto>(
            _context.FormAnswers
            .Where(fa => fa.FormId == request.FormId));
    }
}
