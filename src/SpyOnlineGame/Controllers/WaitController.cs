using Htmx;
using Microsoft.AspNetCore.Mvc;
using SpyOnlineGame.Web.Hypermedia;

namespace SpyOnlineGame.Controllers;

public class WaitController : Controller
{
    public IActionResult Index(int id)
    {
        var hypermedia = new WaitHypermedia(Request, id);
        
        if (hypermedia.IsNotFound)
        {
            if (!hypermedia.IsHtmx) return RedirectToAction("Index", "Home");

            Response.Htmx(h => h.Redirect(Url.Action("Index", "Home")!));
        }
        if (hypermedia.IsGameStarted)
        {
            Response.Htmx(h => h.Redirect(Url.Action("Index", "Game", new { id })!));
        }
        if (hypermedia.IsHtmx && hypermedia.HasOldData()) return NoContent();

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

    public void SetName(int id, string name)
    {
        var hypermedia = new WaitHypermedia(Request, id);

        hypermedia.SetName(name);
    }

    public IActionResult ShowRules(int id)
    {
        var hypermedia = new WaitHypermedia(Request, id);

        ViewBag.Id = id;
        ViewBag.IsShow = hypermedia.IsShowRules;
        return PartialView("Partial/ShowRulesPartial");
    }

    public IActionResult SwitchShowRules(int id)
    {
        var hypermedia = new WaitHypermedia(Request, id);

        hypermedia.SwitchShowRules();
        return ShowRules(id);
    }
    
    public IActionResult Kick(int id, int kickId)
    {
        var hypermedia = new WaitHypermedia(Request, id);

        hypermedia.Kick(kickId);

        return Index(id);
    }

    public IActionResult Logout(int id)
    {
        var hypermedia = new WaitHypermedia(Request, id);
        hypermedia.Logout();
        
        return RedirectToAction("Index", "Home");
    }

    public void Start(int id)
    {
        var hypermedia = new WaitHypermedia(Request, id);

        hypermedia.Start();
    }
}