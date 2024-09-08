using System.Linq;
using System.Web.Mvc;
using SpyOnlineGame.Data;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationWebModel model)
        {
            if (PlayersRepository.All.Any(p => p.IsPlay)) return RedirectToAction("Index");

            var player = model.Map();
            var id = PlayersRepository.Add(player);

            return RedirectToAction("Index", "Wait", new { id });
        }

        public ActionResult Rules()
        {
            return View();
        }
    }
}