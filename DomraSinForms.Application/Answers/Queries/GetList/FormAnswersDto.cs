using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Answers;

namespace DomraSinForms.Application.Answers.Queries.GetList;

public class FormAnswersDto : IMapWith<FormAnswers>
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
    public List<Answer> Answers { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<FormAnswersDto, FormAnswers>()
            .ReverseMap();
    }
}
