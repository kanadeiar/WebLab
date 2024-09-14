using System;
using System.Collections.Generic;
using System.Linq;
using SpyOnlineGame.Data;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class WaitWebModel
    {
        public static WaitWebModel Create(int id, Player current, bool isMayBeStart)
        {
            return new WaitWebModel
            {
                Id = id,
                Current = current?.Map() ?? PlayerWebModel.Default,
                All = PlayersRepository.All.Select(p => p.Map()),
                IsMayBeStart = isMayBeStart,
            };
        }

        public int Id { get; set; }
        public PlayerWebModel Current { get; set; }
        public IEnumerable<PlayerWebModel> All { get; set; } = Array.Empty<PlayerWebModel>();
        public bool IsMayBeStart { get; set; }
    }
}