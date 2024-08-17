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

        return (hypermedia.IsHtmx) 
            ? PartialView("Partial/WaitPartial", hypermedia.Model()) 
            : View(hypermedia.Model());
    }

    public IActionResult SwitchReady(int id)
    {
        var hypermedia = new WaitHypermedia(Request, id);

        hypermedia.SwitchReady();

        return Index(id);
    }
}