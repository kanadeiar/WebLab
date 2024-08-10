using Microsoft.AspNetCore.Mvc;

namespace Resistance.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}