using System.Web.Mvc;

namespace SpyOnlineGame.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}