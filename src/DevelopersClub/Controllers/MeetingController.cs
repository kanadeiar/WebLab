using DevelopersClub.Data;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersClub.Controllers;

public class MeetingController : Controller
{
    public IActionResult Index(int id)
    {
        var models = DevelopersRepository.All.ToArray();
        var developer = DevelopersRepository.GetById(id);
        if (developer is null) return NotFound();
        
        ViewBag.Id = id;
        ViewBag.Name = developer.Name ?? string.Empty;
        return View(models);
    }

    public IActionResult MeetingPartial(int id)
    {
        var models = DevelopersRepository.All.ToArray();
        var developer = DevelopersRepository.GetById(id);
        if (developer is null) return NotFound();

        ViewBag.Id = id;
        ViewBag.Name = developer.Name ?? string.Empty;
        return PartialView("Partial/MeetingPartial", models);
    }
}