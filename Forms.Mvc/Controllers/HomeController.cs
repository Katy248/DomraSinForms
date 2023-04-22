using System.Diagnostics;
using Forms.Mvc.Data;
using Forms.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        /*_context.Forms.Add(new DomraSinForms.Domen.Models.Form
        {
            CreatorId = "",
            Title = "Home",
            Description = "Home",
            Questions = new()
            {
                new Question{ IsRequired = true, Text = "q1" }, 
            }
        });
        _context.SaveChanges();*/
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
