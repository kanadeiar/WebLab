using Htmx;
using Microsoft.AspNetCore.Mvc;
using ProgrammersClub.Data;
using ProgrammersClub.Models;
using ProgrammersClub.Web.Models;

namespace ProgrammersClub.Controllers;

public class ClubController : Controller
{
    public IActionResult Index(int id)
    {
        var all = MembersRepository.All.ToArray();
        var current = MembersRepository.GetById(id);
        if (current is null) return NotFound();

        var model = new ClubWebModel
        {
            Id = id,
            Current = current,
            All = all,
            Selected = current.Subject,
        };

        if (Request.IsHtmx())
        {
            return PartialView("Partial/ClubPartial", model);
        }
        return View(model);
    }

    public IActionResult Select(int id, SubjectCode? selected)
    {
        var current = MembersRepository.GetById(id);
        if (current is null) return NoContent();
        current.Subject = selected;
        return Index(id);
    }
}