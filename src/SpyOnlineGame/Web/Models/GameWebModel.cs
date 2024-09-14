using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class GameWebModel
    {
        public static GameWebModel Create(int id, Player current, string firstName)
        {
            return new GameWebModel
            {
                Id = id,
                Current = current ?? new Player(),
                FirstName = firstName,
            };
        }

        public int Id { get; private set; }
        public Player Current { get; private set; }
        public string FirstName { get; private set; }
    }
}