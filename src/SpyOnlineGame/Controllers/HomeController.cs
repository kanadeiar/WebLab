using Microsoft.AspNetCore.Mvc;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Player player)
    {
        return View("Index");
    }

    public IActionResult Rules()
    {
        return View();
    }
}