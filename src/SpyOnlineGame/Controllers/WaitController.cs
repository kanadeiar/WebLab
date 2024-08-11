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
        if (player is null)
        {
            return RedirectToAction("Index", "Home");
        }
        
        ViewBag.Id = id;
        ViewBag.Name = player.Name ?? string.Empty;

        if (Request.IsHtmx())
        {
            return PartialView("Partial/IndexPartial", models);
        }

        return View(models);
    }
}