using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Queries.GetList;
public class QuestionBaseDto : IMapWith<QuestionBase>
{
    public string Id { get; set; }
    public string QuestionText { get; set; }
    public int Index { get; set; }

    public void Mapping(Profile profile)
    {
        profile.
            CreateMap<QuestionBase,  QuestionBaseDto>();
    }
}
