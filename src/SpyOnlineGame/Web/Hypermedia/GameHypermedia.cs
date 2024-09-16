using System;
using System.Linq;
using System.Web;
using SpyOnlineGame.Common;
using SpyOnlineGame.Data;
using SpyOnlineGame.Models;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Web.Hypermedia
{
    public class GameHypermedia
    {
        private static string _location;
        private static string _firstName;
        private readonly Random _rand = new Random();
        private readonly HttpRequestBase _request;
        private readonly int _id;
        private readonly Player _current;

        public bool IsHtmx => _request.Headers.AllKeys.Contains("hx-request");

        public bool IsNotFound => _current is null;

        public bool IsNoContent => IsHtmx && HasOldData();

        public bool IsNeedInit => 
            string.IsNullOrEmpty(_location) && PlayersRepository.All.Any(p => p.IsPlay);

        public GameHypermedia(HttpRequestBase request, int id)
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

        public void Init()
        {
            if (!IsNeedInit) return;
            var all = PlayersRepository.All.ToArray();
            var firstNum = _rand.Next(all.Length);
            _firstName = all[firstNum].Name;
            _location = LocationsSource.GetRandomLocation();
            var spyNum = _rand.Next(all.Length);
            all[spyNum].Role = RoleCode.Spy;
        }

        public void Select(int votePlayerId)
        {
            _current.VotePlayerId = votePlayerId;
            PlayersRepository.IsNeedAllUpdate();
        }

        public void Confirm()
        {
            if (!GameHelpers.CheckMayBeVote(_id)) return;
            var votePlayerId = VotedHelpers.GetVotedPlayerId();
            VotedHelpers.VotedOfPlayer(votePlayerId);
        }

        public LocationWebModel Location(bool isShow) =>
            LocationWebModel.Create(_id, _current, _location, !isShow);

        public GameWebModel Model() =>
            GameWebModel.Create(_id, _current, _firstName);
    }
}