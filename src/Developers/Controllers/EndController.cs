using Developers.Data;
using Developers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Developers.Controllers;

public class EndController : Controller
{
    public IActionResult Index(int id)
    {
        if (GameController.Code != GameCode.GameEnd)
        {
            return NoContent();
        }

        var player = PlayersRepository.Get(id);
        ViewBag.Id = id;
        ViewBag.Spy = PlayersRepository.Players.FirstOrDefault(x => x.Role == RoleCode.Spy).Name;
        ViewBag.Honests = PlayersRepository.Players.Where(x => x.Role == RoleCode.Honest).Select(x => x.Name).ToArray();

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