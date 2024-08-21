using Microsoft.AspNetCore.Mvc;
using ProgrammersClub.Data;
using ProgrammersClub.Models;

namespace ProgrammersClub.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(Member member)
    {
        if (!ModelState.IsValid) return View("Index", member);

        var id = MembersRepository.Add(member);
        return RedirectToAction("Index", "Club", new { id });
    }

    public IActionResult Rules()
    {
        return View();
    }
}