using Htmx;
using Microsoft.AspNetCore.Mvc;
using ProgrammersClub.Models;
using ProgrammersClub.Web.Hypermedia;

namespace ProgrammersClub.Controllers;

public class ClubController : Controller
{
    public IActionResult Index(int id)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        if (hypermedia.IsNotFound)
        {
            if (!hypermedia.IsHtmx) return RedirectToAction("Index", "Home");

            Response.Htmx(h => h.Redirect(Url.Action("Index", "Home")!));
            return NoContent();
        }

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

    public void ChangeName(int id, string name)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        hypermedia.ChangeName(name);
    }

    public IActionResult SwitchReady(int id)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        hypermedia.SwitchReady();

        return PartialView("Partial/ReadyPartial", hypermedia.Model());
    }

    public IActionResult Logout(int id)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        hypermedia.Kick(id);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Kick(int id, int memberId)
    {
        var hypermedia = new ClubHypermedia(Request, id);
        hypermedia.Kick(memberId);

        return Index(hypermedia.Id);
    }
}