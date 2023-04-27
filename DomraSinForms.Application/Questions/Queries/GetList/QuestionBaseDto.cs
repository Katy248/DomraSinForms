using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Queries.GetList;
public class QuestionBaseDto : IMapWith<QuestionBase>
{
    public string Id { get; set; }
    public string QuestionText { get; set; }
    public int Index { get; set; }
    public string Type { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<QuestionBase, QuestionBaseDto>()
            .ForMember(dto => dto.Type, opt => opt.MapFrom(q => q.GetType().ToString()));
    }
}
