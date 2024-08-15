using Microsoft.AspNetCore.Mvc;
using SpyOnlineGame.Web.Hypermedia;

namespace SpyOnlineGame.Controllers;

public class WaitController : Controller
{
    public IActionResult Index(int id)
    {
        var hypermedia = new WaitHypermedia(Request, id);

        if (hypermedia.IsNotFound) return NotFound();
        if (hypermedia.HasOldData()) return NoContent();

        if (hypermedia.IsHtmx)
        {
            return PartialView("Partial/WaitPartial", hypermedia.Model());
        }

        return View(hypermedia.Model());
    }
}