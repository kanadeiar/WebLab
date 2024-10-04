using System.Net;
using System.Web.Mvc;
using SpyOnlineGame.Web.Hypermedia;

namespace SpyOnlineGame.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index(int id)
        {
            var hypermedia = new GameHypermedia(Request, id);
            if (hypermedia.IsNotFound)
            {
                if (!hypermedia.IsHtmx) return RedirectToAction("Index", "Home");
                Response.Headers.Add("hx-redirect", Url.Action("Index", "Home"));
            }
            if (hypermedia.IsNeedInit) hypermedia.Init();
            if (hypermedia.IsEndGame)
            {
                if (!hypermedia.IsHtmx) return RedirectToAction("Index", "End", 
                    new { id });
                Response.Headers.Add("hx-redirect", Url.Action("Index", "End", 
                    new { id }));
            }
            if (hypermedia.IsNoContent)
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);

            if (hypermedia.IsHtmx)
            {
                return PartialView("Partial/VotingPartial", hypermedia.Model());
            }
            return View(hypermedia.Model());
        }

        public ActionResult Location(int id, bool isShow)
        {
            var hypermedia = new GameHypermedia(Request, id);
            var model = hypermedia.Location(isShow);
            return PartialView("Partial/LocationPartial", model);
        }

        public ActionResult Select(int id, int votePlayerId)
        {
            var hypermedia = new GameHypermedia(Request, id);
            hypermedia.Select(votePlayerId);
            return Index(id);
        }

        public void Confirm(int id)
        {
            var hypermedia = new GameHypermedia(Request, id);
            hypermedia.Confirm();
        }
    }
}