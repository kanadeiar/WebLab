using SpyOnlineGame.Data;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class PlayerWebModel
    {
        public static PlayerWebModel Default => new PlayerWebModel();
        public static PlayerWebModel Create(Player current)
        {
            return new PlayerWebModel
            {
                Id = current.Id,
                Name = current.Name,
                IsReady = current.IsReady,
                Role = current.Role,
                VotePlayerId = current.VotePlayerId,
                VotePlayerName = PlayersRepository.GetById(current.VotePlayerId)?
                    .Name ?? "Сомневается",
                IsVoted = current.IsVoted,
            };
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsReady { get; private set; }
        public RoleCode Role { get; private set; }
        public int VotePlayerId { get; set; }
        public string VotePlayerName { get; set; }
        public bool IsVoted { get; set; }
    }
}