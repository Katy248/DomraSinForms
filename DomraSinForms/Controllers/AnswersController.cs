using Microsoft.AspNetCore.Mvc;

namespace DomraSinForms.Controllers;

public class AnswersController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Fill(string id)
    {
        return View();
    }
    public IActionResult See(string id)
    {
        return View();
    }
}
