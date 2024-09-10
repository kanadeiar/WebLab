using System.Linq;
using System.Web;
using SpyOnlineGame.Data;
using SpyOnlineGame.Models;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Web.Hypermedia
{
    public class GameHypermedia
    {
        private readonly HttpRequestBase _request;
        private readonly int _id;
        private readonly Player _current;

        public bool IsHtmx => _request.Headers.AllKeys.Contains("hx-request");

        public bool IsNotFound => _current is null;

        public GameHypermedia(HttpRequestBase request, int id)
        {
            _request = request;
            _id = id;

            _current = PlayersRepository.GetById(_id);
        }

        public GameWebModel Model()
        {
            return new GameWebModel
            {
                Id = _id,
                Current = _current ?? new Player(),
            };
        }
    }
}