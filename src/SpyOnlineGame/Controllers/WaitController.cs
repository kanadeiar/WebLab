using System.Net;
using System.Web.Mvc;
using SpyOnlineGame.Web.Hypermedia;

namespace SpyOnlineGame.Controllers
{
    public class WaitController : Controller
    {
        public ActionResult Index(int id)
        {
            var hypermedia = new WaitHypermedia(Request, id);
            if (hypermedia.IsNotFound)
            {
                if (!hypermedia.IsHtmx) return RedirectToAction("Index", "Home");
                Response.Headers.Add("hx-redirect", Url.Action("Index", "Home"));
            }
            if (hypermedia.IsGameStarted)
            {
                Response.Headers.Add("hx-redirect", Url.Action("Index", "Game", new { id }));
            }
            if (hypermedia.IsNoContent) 
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);

            if (hypermedia.IsHtmx)
            {
                return PartialView("Partial/WaitPartial", hypermedia.Model());
            }
            return View(hypermedia.Model());
        }

        public ActionResult SwitchReady(int id)
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

        public ActionResult Kick(int id, int playerId)
        {
            var hypermedia = new WaitHypermedia(Request, id);
            hypermedia.Kick(playerId);
            return Index(id);
        }

        public ActionResult Logout(int id)
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
}