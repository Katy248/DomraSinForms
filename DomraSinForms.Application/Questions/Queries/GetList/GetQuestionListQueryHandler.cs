using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Questions;
using Forms.Mvc.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Queries.GetList;
public class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, IEnumerable<IMapWith<QuestionBase>>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionListQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<IMapWith<QuestionBase>>> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .FirstOrDefaultAsync(f => f.Id == request.FormId);
        if (form is null)
            return Array.Empty<IMapWith<QuestionBase>>();

        return _mapper.ProjectTo<QuestionBaseDto>(
            _context.Questions.Where(q => q.FormId == request.FormId).OrderBy(q => q.Index));
    }
}
