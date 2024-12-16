using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.UpdateTextQuestion;
public class UpdateTextQuestionCommand : UpdateQuestionBaseCommand<TextQuestion>, IMapWith<QuestionBase>
{
    public TextQuestionType Type { get; set; }

    public static UpdateTextQuestionCommand FromModel(TextQuestion q)
    {
        return new()
        {
            Id = q.Id,
            Type = q.Type, 
            QuestionText = q.QuestionText, 
            Index = q.Index , 
            IsRequired = q.IsRequired
        };
    }
}
