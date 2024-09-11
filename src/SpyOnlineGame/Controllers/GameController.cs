﻿using System.Web.Mvc;
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

        public ActionResult Location(int id, bool isShow)
        {
            var hypermedia = new GameHypermedia(Request, id);
            var model = hypermedia.Location(isShow);
            return PartialView("Partial/LocationPartial", model);
        }
    }
}