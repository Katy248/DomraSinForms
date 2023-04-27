using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Answers;

namespace DomraSinForms.Application.Answers.Queries.Get;

public class GetFormAnswersQuery : IGetSingleRequest<FormAnswers>
{
    public string Id { get; set; }
}
