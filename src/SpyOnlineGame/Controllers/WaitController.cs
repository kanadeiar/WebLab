using Htmx;
using Microsoft.AspNetCore.Mvc;
using SpyOnlineGame.Data;

namespace SpyOnlineGame.Controllers;

public class WaitController : Controller
{
    public IActionResult Index(int id)
    {
        var models = PlayersRepository.All.ToArray();
        var player = PlayersRepository.Get(id);
        if (player is null) return RedirectToAction("Index", "Home");
        
        ViewBag.Id = id;
        ViewBag.Name = player.Name ?? string.Empty;

        return View(models);
    }

    public IActionResult WaitPartial(int id)
    {
        var models = PlayersRepository.All.ToArray();
        var player = PlayersRepository.Get(id);
        if (player is null)
        {
            Response.Htmx(x => x.Redirect(Url.Action("Index", "Home")!));
            return NoContent();
        }

        ViewBag.Id = id;
        ViewBag.Name = player.Name ?? string.Empty;

        return PartialView("Partial/WaitPartial", models);
    }
}