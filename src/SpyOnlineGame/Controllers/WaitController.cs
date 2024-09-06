﻿using System.Web.Mvc;
using SpyOnlineGame.Web.Hypermedia;

namespace SpyOnlineGame.Controllers
{
    public class WaitController : Controller
    {
        public ActionResult Index(int id)
        {
            var hypermedia = new WaitHypermedia(Request, id);
            if (hypermedia.IsNotFound) return new HttpNotFoundResult();

            if (hypermedia.IsHtmx)
            {
                return PartialView("Partial/WaitPartial", hypermedia.Model());
            }
            return View(hypermedia.Model());
        }
    }
}