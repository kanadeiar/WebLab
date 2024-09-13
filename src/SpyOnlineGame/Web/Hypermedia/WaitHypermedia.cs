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

        public bool IsMayBeStart => PlayersRepository.All.Count() >= 3 && 
            PlayersRepository.All.All(x => x.IsReady) && !IsGameStarted;

        public bool IsGameStarted =>
            PlayersRepository.All.Any(p => p.IsPlay);

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

        public void SetName(string name)
        {
            if (_current is null || _current.Name == name) return;
            _current.Name = name;
            PlayersRepository.IsNeedAllUpdate();
        }

        public void Kick(int playerId)
        {
            PlayersRepository.Remove(playerId);
        }

        public void Logout()
        {
            PlayersRepository.Remove(_id);
        }

        public void Start()
        {
            if (!IsMayBeStart) return;
            foreach (var each in PlayersRepository.All)
            {
                each.IsPlay = true;
            }
            PlayersRepository.IsNeedAllUpdate();
        }

        public WaitWebModel Model()
        {
            return new WaitWebModel
            {
                Id = _id,
                Current = _current?.Map() ?? new PlayerWebModel(),
                All = PlayersRepository.All.Select(p => p.Map()),
                IsMayBeStart = IsMayBeStart,
            };
        }
    }
}