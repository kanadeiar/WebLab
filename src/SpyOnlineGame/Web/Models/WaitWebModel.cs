using System;
using System.Collections.Generic;
using System.Linq;
using SpyOnlineGame.Data;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class WaitWebModel
    {
        public static WaitWebModel Create(int id, Player current, 
            bool isMayBeStart)
        {
            return new WaitWebModel
            {
                Id = id,
                Current = PlayerWebModel.Create(current) ?? PlayerWebModel.Default,
                All = PlayersRepository.All.Select(PlayerWebModel.Create),
                IsMayBeStart = isMayBeStart,
            };
        }

        public int Id { get; private set; }
        public PlayerWebModel Current { get; private set; }
        public IEnumerable<PlayerWebModel> All { get; private set; } 
            = Array.Empty<PlayerWebModel>();
        public bool IsMayBeStart { get; private set; }
    }
}