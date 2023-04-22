using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Forms.Queries.GetList;

public class FormDto : IMapWith<Form>
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
    public List<QuestionBase> Questions { get; set; } = new();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<FormDto, Form>()
            .ReverseMap();
    }
}
