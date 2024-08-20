using Microsoft.AspNetCore.Mvc;
using ProgrammersClub.Data;

namespace ProgrammersClub.Controllers;

public class ClubController : Controller
{
    public IActionResult Index(int id)
    {
        var models = MembersRepository.All.ToArray();
        var developer = MembersRepository.GetById(id);
        if (developer is null) return NotFound();

        ViewBag.Id = id;
        ViewBag.Name = developer.Name ?? string.Empty;
        return View(models);
    }

    public IActionResult ClubPartial(int id)
    {
        var models = MembersRepository.All.ToArray();
        var developer = MembersRepository.GetById(id);
        if (developer is null) return NotFound();

        ViewBag.Id = id;
        ViewBag.Name = developer.Name ?? string.Empty;
        return PartialView("Partial/ClubPartial", models);
    }
}