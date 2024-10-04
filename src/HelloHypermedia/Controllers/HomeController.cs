using System.Web.Mvc;

namespace HelloHypermedia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Hello()
        {
            return "Привет, гипермедиа!";
        }
    }
}