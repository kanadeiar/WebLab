using System;
using System.Collections.Generic;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class WaitWebModel
    {
        public int Id { get; set; }
        public Player Current { get; set; }
        public IEnumerable<Player> All { get; set; } = Array.Empty<Player>();
        public bool IsMayBeStart { get; set; }
    }
}