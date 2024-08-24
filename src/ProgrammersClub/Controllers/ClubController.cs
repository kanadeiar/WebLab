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
            return PartialView("Partial/ClubPartial", hypermedia.Model());
        }
        return View(hypermedia.Model());
    }

    public IActionResult Select(int id, SubjectCode? selected)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        hypermedia.SelectSubject(selected);

        if (hypermedia.IsNotFound) return NoContent();
        return Index(hypermedia.Id);
    }
}