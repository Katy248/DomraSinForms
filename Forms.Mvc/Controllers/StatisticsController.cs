using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Application.Forms.Queries.Get;
using Forms.Mvc.Models.Statistics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Answers(string formId)
        {
            var model = new FormAnswersListViewModel
            {
                AnswersDto = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId }),
                Form = await _mediator.Send(new GetFormQuery { Id = formId })                        
            };
            
            return View(model);
        }
    }
}

