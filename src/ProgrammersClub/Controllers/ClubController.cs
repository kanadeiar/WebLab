using Microsoft.AspNetCore.Mvc;
using ProgrammersClub.Models;
using ProgrammersClub.Web.Hypermedia;

namespace ProgrammersClub.Controllers;

public class ClubController : Controller
{
    public IActionResult Index(int id)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        if (hypermedia.IsNotFound) return NotFound();

        if (hypermedia.IsHtmx)
        {
            if (hypermedia.HasOldData()) return NoContent();

            return PartialView("Partial/ClubPartial", hypermedia.Model());
        }
        return View(hypermedia.Model());
    }

    public IActionResult Select(int id, SubjectCode? selected)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        hypermedia.SelectSubject(selected);

        return Index(hypermedia.Id);
    }

    public IActionResult SwitchReady(int id)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        hypermedia.SwitchReady();

        return PartialView("Partial/ReadyPartial", hypermedia.Model());
    }
}