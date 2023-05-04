using AutoMapper;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Forms.Commands.Update
{
    public class UpdateFormCommand : IUpdateRequest<Form>, IMapWith<Form>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Form, UpdateFormCommand>()
                .ReverseMap();
        }
    }
}
