using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpyOnlineGame.Web.Models
{
    public class GameWebModel
    {
        public int Id { get; set; }
        public PlayerWebModel Current { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<PlayerWebModel> All { get; set; } = Array.Empty<PlayerWebModel>();
        public IEnumerable<SelectListItem> PlayersVariants { get; set; } = Array.Empty<SelectListItem>();
    }
}