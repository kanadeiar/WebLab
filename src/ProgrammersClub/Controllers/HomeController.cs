using Microsoft.AspNetCore.Mvc;
using ProgrammersClub.Web.Hypermedia;
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
        var hypermedia = new RegistrationHypermedia(Request, ModelState, model);

        if (hypermedia.IsHtmx) return PartialView("Partial/RegistrationPartial", model);
        if (hypermedia.IsInvalid) return View("Index", model);

        hypermedia.RegisterNewMember();
        
        return RedirectToAction("Index", "Club", new { hypermedia.Id });
    }

    public IActionResult Rules()
    {
        return View();
    }
}