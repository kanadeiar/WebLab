using Htmx;
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
        validate(member);
        if (Request.IsHtmx()) return PartialView("Partial/RegistrationPartial", member);
        if (!ModelState.IsValid) return View("Index", member);

        var id = MembersRepository.Add(member);
        return RedirectToAction("Index", "Club", new { id });
    }

    private void validate(Member member)
    {
        if (MembersRepository.All.Any(x => x.Name == member.Name))
        {
            ModelState.AddModelError("Name", "Такое имя уже занято");
        }
    }

    public IActionResult Rules()
    {
        return View();
    }
}