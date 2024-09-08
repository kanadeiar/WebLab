using System.Linq;
using System.Web;
using SpyOnlineGame.Data;
using SpyOnlineGame.Models;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Web.Hypermedia
{
    public class WaitHypermedia
    {
        private readonly HttpRequestBase _request;
        private readonly int _id;
        private readonly Player _current;
        
        public bool IsHtmx => _request.Headers.AllKeys.Contains("hx-request");

        public bool IsNotFound => _current is null;

        public bool IsNoContent => IsHtmx && HasOldData();

        public WaitHypermedia(HttpRequestBase request, int id)
        {
            _request = request;
            _id = id;

            _current = PlayersRepository.GetById(_id);
        }

        public bool HasOldData()
        {
            if (_current?.IsNeedUpdate != true) return true;
            _current.IsNeedUpdate = false;
            return false;
        }

        public void SwitchReady()
        {
            if (_current is null) return;
            _current.IsReady = !_current.IsReady;
            PlayersRepository.IsNeedAllUpdate();
        }

        public WaitWebModel Model()
        {
            return new WaitWebModel
            {
                Id = _id,
                Current = _current ?? new Player(),
                All = PlayersRepository.All,
            };
        }
    }
}