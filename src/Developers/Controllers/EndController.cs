using Developers.Data;
using Developers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Developers.Controllers;

public class EndController : Controller
{
    public IActionResult Index(int id)
    {
        var player = PlayersRepository.Get(id);
        if (Game.Code != GameCode.GameEnd || player == null)
        {
            return NotFound();
        }
        PlayersRepository.Remove(id);

        ViewBag.Id = id;
        ViewBag.Spy = Game.Spy;
        ViewBag.Honests = Game.Honests;

        if (GameController.WiningTeam == RoleCode.Honest)
        {
            if (player.Role == RoleCode.Honest)
            {
                return View("HonestWin");
            }

            return View("SpyLoss");
        }

        if (player.Role == RoleCode.Spy)
        {
            return View("SpyWin");
        }

        return View("HonestLoss");
    }
}