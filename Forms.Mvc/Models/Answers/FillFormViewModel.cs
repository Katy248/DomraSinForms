using System.Collections.Immutable;
using DomraSinForms.Application.Answers.Commands.Create;
using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Domain.Models.Answers;
using Forms.Mvc.Models.Answers.AnswersModels;

namespace Forms.Mvc.Models.Answers;

public class FillFormViewModel
{
    private readonly FormAnswersDto? _dto;

    public FillFormViewModel() { }
    public FillFormViewModel(FormAnswersDto command)
    {
        _dto = command;
        Answers = new AnswerFactory().GetAnswers(command.Answers)?.OrderBy(a => a.Index)?.ToArray() ?? Array.Empty<IAnswerViewModel>();
    }
    public FillFormViewModel(FormAnswers command)
    {
        /*_dto = command;*/
        Answers = new AnswerFactory().GetAnswers(command.Answers)?.OrderBy(a => a.Index)?.ToArray() ?? Array.Empty<IAnswerViewModel>();
    }
    public string FormId => _dto?.FormId ?? "";
    public IAnswerViewModel[] Answers { get; set; }
    public bool RequiredQuestionsAnswered => Answers?.Where(a => a.IsRequired && string.IsNullOrWhiteSpace(a.Value)).Count() == 0;
}
