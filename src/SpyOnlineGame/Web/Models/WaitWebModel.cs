using System;
using System.Collections.Generic;

namespace SpyOnlineGame.Web.Models
{
    public class WaitWebModel
    {
        public int Id { get; set; }
        public PlayerWebModel Current { get; set; }
        public IEnumerable<PlayerWebModel> All { get; set; } = Array.Empty<PlayerWebModel>();
        public bool IsMayBeStart { get; set; }
    }
}