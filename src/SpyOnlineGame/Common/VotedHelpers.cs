using System.Linq;
using SpyOnlineGame.Data;

namespace SpyOnlineGame.Common
{
    public static class VotedHelpers
    {
        public static int? GetVotedPlayerId()
        {
            var grouped = GameHelpers.GroupedByVotePlayers(0);
            var result = grouped
                .Select(p => new { p.Key, count = p.Count() })
                .OrderByDescending(p => p.count)
                .FirstOrDefault()?.Key;
            return result;
        }

        public static void VotedOfPlayer(int? votePlayerId)
        {
            if (votePlayerId == null) return;
            var votedPlayer = PlayersRepository.GetById((int)votePlayerId);
            votedPlayer.IsVoted = true;
            foreach (var each in PlayersRepository.All)
            {
                each.VotePlayerId = 0;
            }
            PlayersRepository.IsNeedAllUpdate();
        }
    }
}