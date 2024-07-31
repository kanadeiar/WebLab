using Developers.Data;
using Developers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Developers.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string name)
    {
        var player = new Player(name);

        PlayersRepository.Add(player);

        return RedirectToAction("Wait", new { name });
    }

    public IActionResult Wait(string name)
    {
        var players = PlayersRepository.Players;
        ViewBag.Name = name;
        
        return View(players);
    }
    
    public IActionResult Ready(string name)
    {
        var players = PlayersRepository.Players;
        var player = PlayersRepository.Get(name);
        ViewBag.Name = name;

        if (bool.TryParse(Request.Headers["ready"], out var ready))
        {
            player.IsReady = ready;
        }

        ViewBag.IsReady = player.IsReady;
        return PartialView("Partials/WaitPartial", players);
    }
}