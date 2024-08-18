using DevelopersClub.Data;
using DevelopersClub.Web.Models;
using Htmx;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersClub.Controllers;

public class MeetingController : Controller
{
    public IActionResult Index(int id)
    {
        var all = DevelopersRepository.All.ToArray();
        var current = DevelopersRepository.GetById(id);
        if (current is null) return NotFound();

        var model = new MeetingWebModel
        {
            Id = id,
            Current = current,
            All = all,
        };

        if (Request.IsHtmx())
        {
            return PartialView("Partial/MeetingPartial", model);
        }
        
        return View(model);
    }
}