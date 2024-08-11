using Microsoft.AspNetCore.Mvc;
using SpyOnlineGame.Data;

namespace SpyOnlineGame.Controllers;

public class WaitController : Controller
{
    public IActionResult Index(int id)
    {
        var models = PlayersRepository.All.ToArray();
        var player = PlayersRepository.Get(id);

        ViewBag.Name = player?.Name ?? "Неизвестно";
        return View(models);
    }
}