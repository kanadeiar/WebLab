using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SpyOnlineGame.Data;
using SpyOnlineGame.Models;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Common
{
    public static class GameHelpers
    {
        public static IEnumerable<SelectListItem> CreateVariantsForDropDown(
            this Player current, int id)
        {
            var othersLivesPlayer = CreateAllPlayers().Where(p => p.Id != id);
            var variants = new List<SelectListItem> { new SelectListItem
                { Value = "0", Text = "Сомневаюсь" } };
            variants.AddRange(othersLivesPlayer.Select(p =>
                new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                    Selected = p.Id == current.VotePlayerId,
                }));
            return variants;
        }

        public static bool CheckMayBeVote(int id)
        {
            return MaxVoteCount(id) >= CountOfLivesPlayers() - 1;
        }

        public static int MaxVoteCount(int id)
        {
            var grouped = GroupedByVotePlayers(id);
            if (!grouped.Any()) return 0;
            return grouped.Select(p => p.Count()).Max();
        }

        public static IGrouping<int, PlayerWebModel>[] GroupedByVotePlayers(int id)
        {
            var actualPlayers = CreateAllPlayers().Where(p => p.VotePlayerId != 0
                                                              && p.VotePlayerId != id);
            var result = actualPlayers.GroupBy(p => p.VotePlayerId).ToArray();
            return result;
        }

        public static int CountOfLivesPlayers()
        {
            return CreateAllPlayers().Count(p => !p.IsVoted);
        }

        public static IEnumerable<PlayerWebModel> CreateAllPlayers()
        {
            return PlayersRepository.All.Where(p => p.IsPlay)
                .Select(PlayerWebModel.Create);
        }
    }
}