using Developers.Data;
using Developers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Developers.Controllers;

public class HomeController : Controller
{
    private static bool isGame;

    public IActionResult Index()
    {
        var player = new Player();

        return View(player);
    }

    [HttpPost]
    public IActionResult Login(Player player)
    {
        if (ModelState.IsValid == false)
        {
            return View("Index", player);
        }

        PlayersRepository.Add(player);
        
        return RedirectToAction("Wait", new { player.Id });
    }

    public IActionResult Logout(int id)
    {
        PlayersRepository.Remove(id);

        return RedirectToAction("Index");
    }

    public IActionResult Wait(int id)
    {
        var players = PlayersRepository.Players;
        var player = PlayersRepository.Get(id);

        if (player is null || player.Notify == false) return NoContent();
        player.Notify = false;

        ViewBag.Id = id;
        ViewBag.Name = player.Name;
        ViewBag.IsReady = player.IsReady;
        
        if (Request.Headers.ContainsKey("HX-Request"))
        {
            if (isGame)
            {
                Response.Headers.Add("HX-Redirect", Url.Action("Index", "Game", new { id }));
            }

            return PartialView("Partial/WaitPartial", players);
        }

        return View(players);
    }

    public void Name(int id, string name)
    {
        var player = PlayersRepository.Get(id);
        player.Name = name;
        PlayersRepository.Notify();
    }

    public IActionResult Ready(int id, bool isReady)
    {
        var player = PlayersRepository.Get(id);

        player.IsReady = !isReady;

        if (PlayersRepository.Players.Count() == 3 && PlayersRepository.Players.All(x => x.IsReady))
        {
            isGame = true;
        }

        PlayersRepository.Notify();
        
        return Wait(id);
    }
}