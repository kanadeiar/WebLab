using SpyOnlineGame.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web.Mvc;
using SpyOnlineGame.Data;

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
                All = CreateAllPlayers(),
                PlayersVariants = CreateVariantsForDropDown(id, current),
                IsMayBeVote = CheckMayBeVote(id),
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

        private static IEnumerable<SelectListItem> CreateVariantsForDropDown(
            int id, Player current)
        {
            var othersLivesPlayer = CreateAllPlayers().Where(p => p.Id != id);
            var variants = new List<SelectListItem> { new SelectListItem 
                { Value = "0", Text = "Сомневается" } };
            variants.AddRange(othersLivesPlayer.Select(p =>
                new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                    Selected = p.Id == current.VotePlayerId,
                }));
            return variants;
        }

        private static bool CheckMayBeVote(int id)
        {
            return MaxVoteCount(id) >= CountOfLivesPlayers() - 1;
        }

        private static int MaxVoteCount(int id)
        {
            var grouped = GroupedByVotePlayers(id);
            if (!grouped.Any()) return 0;
            return grouped.Select(p => p.Count()).Max();
        }

        private static IGrouping<int, PlayerWebModel>[] GroupedByVotePlayers(int id)
        {
            var actualPlayers = CreateAllPlayers().Where(p => p.VotePlayerId != 0 
                                                              && p.VotePlayerId != id);
            var result = actualPlayers.GroupBy(p => p.VotePlayerId).ToArray();
            return result;
        }

        private static int CountOfLivesPlayers()
        {
            return CreateAllPlayers().Count(p => !p.IsVoted);
        }

        private static IEnumerable<PlayerWebModel> CreateAllPlayers()
        {
            return PlayersRepository.All.Where(p => p.IsPlay)
                .Select(PlayerWebModel.Create);
        }
    }
}