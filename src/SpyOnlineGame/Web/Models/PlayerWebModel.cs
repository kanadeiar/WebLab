using SpyOnlineGame.Data;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class PlayerWebModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsReady { get; set; }
        public RoleCode Role { get; set; }
        public int VotePlayerId { get; set; }
        public string VotePlayerName { get; set; }
        public bool IsVoted { get; set; }
    }

    public static class PlayerWebModelExtensions
    {
        public static PlayerWebModel Map(this Player player)
        {
            return new PlayerWebModel
            {
                Id = player.Id,
                Name = player.Name,
                IsReady = player.IsReady,
                Role = player.Role,
                VotePlayerId = player.VotePlayerId,
                VotePlayerName = PlayersRepository.GetById(player.VotePlayerId)?.Name ?? "Сомневается",
                IsVoted = player.IsVoted,
            };
        }
    }
}