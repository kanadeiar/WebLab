using SpyOnlineGame.Models;
using System.Collections.Generic;
using System;
using System.Web.Mvc;
using SpyOnlineGame.Common;

namespace SpyOnlineGame.Web.Models
{
    public class GameWebModel
    {
        public static GameWebModel Create(int id, Player current, string firstName)
        {
            return new GameWebModel
            {
                Id = id,
                Current = PlayerWebModel.Create(current) 
                          ?? PlayerWebModel.Default,
                FirstName = firstName,
                All = GameHelpers.CreateAllPlayers(),
                PlayersVariants = current.CreateVariantsForDropDown(id),
                IsMayBeVote = GameHelpers.CheckMayBeVote(id),
            };
        }

        public int Id { get; private set; }
        public PlayerWebModel Current { get; private set; }
        public string FirstName { get; private set; }
        public IEnumerable<PlayerWebModel> All { get; private set; } 
            = Array.Empty<PlayerWebModel>();
        public IEnumerable<SelectListItem> PlayersVariants { get; private set; } 
            = Array.Empty<SelectListItem>();
        public bool IsMayBeVote { get; private set; }
    }
}