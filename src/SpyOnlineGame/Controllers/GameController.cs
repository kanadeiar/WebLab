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
                return RedirectToAction("Index", "Home");
            }
            if (hypermedia.IsNeedInit) hypermedia.Init();

            if (hypermedia.IsHtmx)
            {
                return PartialView("Partial/VotingPartial", hypermedia.Model());
            }
            return View(hypermedia.Model());
        }
    }
}