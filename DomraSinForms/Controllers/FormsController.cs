using Microsoft.AspNetCore.Mvc;

namespace DomraSinForms.Controllers;

public class FormsController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Details(string id)
    {
        return View();
    }
    public IActionResult Edit(string id)
    {
        return View();
    }
    public IActionResult Delete(string id)
    {
        return View();
    }
}
