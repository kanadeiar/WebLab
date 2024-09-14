using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class PlayerWebModel
    {
        public static PlayerWebModel Default => new PlayerWebModel();

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsReady { get; set; }
        public RoleCode Role { get; set; }
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
            };
        }
    }
}