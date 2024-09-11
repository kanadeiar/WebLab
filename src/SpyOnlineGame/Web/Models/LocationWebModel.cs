using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class LocationWebModel
    {
        public int Id { get; set; }
        public RoleCode Role { get; set; }
        public string Location { get; set; }
        public bool IsShow { get; set; }
    }
}