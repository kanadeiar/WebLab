using System.Linq;
using System.Web.Mvc;
using SpyOnlineGame.Data;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Controllers
{
    public class WaitController : Controller
    {
        public ActionResult Index(int id)
        {
            var all = PlayersRepository.All.ToArray();
            var player = PlayersRepository.GetById(id);
            if (player is null) return new HttpNotFoundResult();

            var model = new WaitWebModel
            {
                Id = id,
                Current = player,
                All = all,
            };

            if (Request.Headers.AllKeys.Contains("hx-request"))
            {
                return PartialView("Partial/WaitPartial", model);
            }
            return View(model);
        }
    }
}