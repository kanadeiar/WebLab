using System.Collections.Generic;
using System.Linq;
using SpyOnlineGame.Models;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Common
{
    public static class RulesHelpers
    {
        public static bool CheckEndGame()
        {
            var lives = CreateLivesPlayers().ToArray();
            var spyCount = lives.Count(p => p.Role == RoleCode.Spy);
            var honestCount = lives.Count(p => p.Role == RoleCode.Honest);
            return spyCount == 0 || honestCount <= spyCount;
        }

        private static IEnumerable<PlayerWebModel> CreateLivesPlayers()
        {
            return GameHelpers.CreateAllPlayers().Where(p => !p.IsVoted);
        }
    }
}