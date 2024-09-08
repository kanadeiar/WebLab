using DevelopersClub.Data;
using DevelopersClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersClub.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(Developer developer)
    {
        var id = DevelopersRepository.Add(developer);

        return RedirectToAction("Index", "Meeting", new { id });
    }

    public IActionResult Rules()
    {
        return View();
    }
}