using Microsoft.AspNetCore.Mvc;

namespace DomraSinForms.Controllers;

public class ReportsController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Create(string id)
    {
        return View();
    }
}
