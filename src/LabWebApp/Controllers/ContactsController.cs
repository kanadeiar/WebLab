using Microsoft.AspNetCore.Mvc;

namespace LabWebApp.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return PartialView("Partial/IndexPartial");
        }
    }
}
