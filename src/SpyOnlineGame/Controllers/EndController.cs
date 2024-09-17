using System.Web.Mvc;

namespace SpyOnlineGame.Controllers
{
    public class EndController : Controller
    {
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}