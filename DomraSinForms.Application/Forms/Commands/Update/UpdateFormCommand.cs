using AutoMapper;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domen.Models;
using DomraSinForms.Domen.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Commands.Update
{
    public class UpdateFormCommand: IUpdateRequest<Form>, IMapWith<Form>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuestionBlock> Questions { get; set; } = new();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Form, UpdateFormCommand>()
                .ReverseMap();
        }
    }
}
