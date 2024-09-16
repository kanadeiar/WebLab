using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class LocationWebModel
    {
        public static LocationWebModel Create(int id, Player current, string location, bool isShow)
        {
            return new LocationWebModel
            {
                Id = id,
                Role = current?.Role ?? RoleCode.Honest,
                Location = location,
                IsShow = isShow,
            };
        }

        public int Id { get; set; }
        public RoleCode Role { get; set; }
        public string Location { get; set; }
        public bool IsShow { get; set; }
    }
}