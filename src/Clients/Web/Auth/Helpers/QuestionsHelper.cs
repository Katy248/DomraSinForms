using DomraSinForms.Domain.Models.Questions;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DomraSinForms.Clients.Web.Blazor.Helpers;

public class QuestionsHelper
{
    public static IEnumerable<SelectListItem> TextQuestionTypesSelect(IViewLocalizer localizer) => new[]
    {
        new SelectListItem(localizer["Text question"]?.Value, ((int)TextQuestionType.Text).ToString()),
        new SelectListItem(localizer["Number question"]?.Value, ((int)TextQuestionType.Number).ToString()),
        new SelectListItem(localizer["Date question"]?.Value, ((int)TextQuestionType.Date).ToString()),
        new SelectListItem(localizer["DateTime question"]?.Value, ((int)TextQuestionType.DateTime).ToString()),
        new SelectListItem(localizer["Time question"]?.Value, ((int)TextQuestionType.Time).ToString()),
        new SelectListItem(localizer["Phone number"]?.Value, ((int)TextQuestionType.PhoneNumber).ToString()),
    };
     public static IEnumerable<SelectListItem> TextQuestionTypesSelect() => new[]
        {
            new SelectListItem("Text question", ((int) TextQuestionType.Text).ToString()),
            new SelectListItem("Number question", ((int) TextQuestionType.Number).ToString()),
            new SelectListItem("Date question", ((int) TextQuestionType.Date).ToString()),
            new SelectListItem("DateTime question", ((int) TextQuestionType.DateTime).ToString()),
            new SelectListItem("Time question", ((int) TextQuestionType.Time).ToString()),
            new SelectListItem("Phone number", ((int) TextQuestionType.PhoneNumber).ToString()),
    
        };
}
