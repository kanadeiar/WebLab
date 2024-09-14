using SpyOnlineGame.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using SpyOnlineGame.Data;

namespace SpyOnlineGame.Web.Models
{
    public class GameWebModel
    {
        public static GameWebModel Create(int id, Player current, string firstName)
        {
            var all = PlayersRepository.All.Where(p => p.IsPlay)
                .Select(PlayerWebModel.Create);

            return new GameWebModel
            {
                Id = id,
                Current = PlayerWebModel.Create(current) 
                          ?? PlayerWebModel.Default,
                FirstName = firstName,
                All = all,
            };
        }

        public int Id { get; private set; }
        public PlayerWebModel Current { get; private set; }
        public string FirstName { get; private set; }
        public IEnumerable<PlayerWebModel> All { get; set; } 
            = Array.Empty<PlayerWebModel>();
    }
}