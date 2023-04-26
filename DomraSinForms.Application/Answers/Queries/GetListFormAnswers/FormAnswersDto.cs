using AutoMapper;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Answers.Queries.GetListFormAnswers
{
    public class FormAnswersDto:IMapWith<FormAnswers>
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
}
