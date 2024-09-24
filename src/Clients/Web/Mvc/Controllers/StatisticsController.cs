using DomraSinForms.Application.Answers.Queries.GetList;
using Forms.Mvc.ViewModels.Statistics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Forms.Mvc.Controllers;

public class StatisticsController : Controller
{
  private readonly IMediator _mediator;
  private readonly ILogger<StatisticsController> _logger;
  private readonly IOutputCacheStore _cache;

  public StatisticsController(IMediator mediator, ILogger<StatisticsController> logger, IOutputCacheStore cache)
  {
    _mediator = mediator;
    _logger = logger;
    _cache = cache;
  }

  /// <summary>
  /// Выводит все вопросы и диаграммы для их ответов.
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
  [Authorize]
  [OutputCache(Duration = 3600, VaryByRouteValueNames = ["id"])]
  public async Task<IActionResult> Summary(string id)
  {
    var vm = new SummaryViewModel
    {
      FormId = id,
      AnswersDto = await _mediator.Send(new GetFormAnswersListQuery { FormId = id }),
    };
    if (vm.AnswersDto is null)
      return NotFound();
    return View(vm);
  }
  /// <summary>
  /// Выводит все ответы одного пользователя.
  /// </summary>
  /// <param name="formId"></param>
  /// <returns></returns>
  [Authorize]
  [OutputCache(Duration = 3600)]
  public async Task<IActionResult> FormAnswersList(string formId)
  {
    var vm = new FormAnswersViewModel
    {
      FormId = formId,
      FormAnswersList = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId })
    };
    if (vm.FormAnswersList is null)
      return NotFound();
    return View(vm);
  }
}
