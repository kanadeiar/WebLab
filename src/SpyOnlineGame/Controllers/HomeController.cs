using Microsoft.AspNetCore.Mvc;
using SpyOnlineGame.Data;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(Player player)
    {
        var id = PlayersRepository.Add(player);

        return RedirectToAction("Index", "Wait", new { id });
    }

    public IActionResult Rules()
    {
        return View();
    }
}