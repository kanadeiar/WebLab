using Microsoft.AspNetCore.Mvc;
using ProgrammersClub.Data;
using ProgrammersClub.Web.Models;

namespace ProgrammersClub.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(RegistrationWebModel model)
    {
        if (!ModelState.IsValid) return View("Index", model);

        var member = model.Map();
        var id = MembersRepository.Add(member);
        return RedirectToAction("Index", "Club", new { id });
    }

    public IActionResult Rules()
    {
        return View();
    }
}