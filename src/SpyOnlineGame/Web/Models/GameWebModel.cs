using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class GameWebModel
    {
        public int Id { get; set; }
        public Player Current { get; set; }
        public string Location { get; set; }
        public string FirstName { get; set; }
    }
}