using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.Update;
public class UpdateQuestionCommand : IUpdateRequest<QuestionBase>, IMapWith<QuestionBase>
{
    public string Id { get; set; }
    public string QuestionText { get; set; }
}
