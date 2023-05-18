using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Answers;

namespace DomraSinForms.Application.Answers.Queries.GetList;

public class FormAnswersDto : IMapWith<FormAnswers>
{
    public string Id { get; set; } = "";
    public string FormId { get; set; } = "";
    public string UserId { get; set; } = "";
    public DateTime CreationDate { get; set; }
    public List<Answer> Answers { get; set; } = new();
    public void Mapping(Profile profile)
    {
        profile.CreateMap<FormAnswersDto, FormAnswers>()
            .ReverseMap();
    }
}
