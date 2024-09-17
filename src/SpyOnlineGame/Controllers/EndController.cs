using System.Web.Mvc;
using SpyOnlineGame.Web.Services;

namespace SpyOnlineGame.Controllers
{
    public class EndController : Controller
    {
        public ActionResult Index(int id)
        {
            var webService = new EndWebService(id);

            return View(webService.Model());
        }
    }
}