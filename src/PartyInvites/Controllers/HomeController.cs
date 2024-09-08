using Microsoft.AspNetCore.Mvc;
using PartyInvites.Data;
using PartyInvites.Models;

namespace PartyInvites.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RequestForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RequestForm(GuestResponse model)
    {
        if (ModelState.IsValid)
        {
            GuestRepository.AddResponse(model);
            return View("Thanks", model);
        }

        return View();
    }
    
    public IActionResult ListResponses()
    {
        var resps = GuestRepository.Responses
            .Where(r => r.WillAttend == true);
        
        return View(resps);
    }
}