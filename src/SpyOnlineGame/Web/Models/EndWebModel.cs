using System;
using System.Collections.Generic;
using System.Linq;
using SpyOnlineGame.Common;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class EndWebModel
    {
        public static EndWebModel Create(Player current)
        {
            var honestPlayers = GameHelpers.CreateAllPlayers().Where(p => p.Role == RoleCode.Honest);
            var spyPlayer = GameHelpers.CreateAllPlayers().First(p => p.Role == RoleCode.Spy);
            var isWinOfHonestPlayers = spyPlayer.IsVoted;
            var isCurrentWin = current.Role == RoleCode.Honest && isWinOfHonestPlayers
                               || current.Role == RoleCode.Spy && !isWinOfHonestPlayers;
            return new EndWebModel
            {
                IsWinOfHonestPlayers = isWinOfHonestPlayers,
                Current = PlayerWebModel.Create(current) ?? PlayerWebModel.Default,
                IsCurrentWin = isCurrentWin,
                HonestPlayers = honestPlayers,
                SpyPlayer = spyPlayer,
            };
        }

        public bool IsWinOfHonestPlayers { get; private set; }
        public PlayerWebModel Current { get; private set; }
        public bool IsCurrentWin { get; private set; }
        public IEnumerable<PlayerWebModel> HonestPlayers { get; private set; } = Array.Empty<PlayerWebModel>();
        public PlayerWebModel SpyPlayer { get; private set; }
    }
}