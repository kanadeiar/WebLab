using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public LocationWebModel Location(bool isShow)
        {
            return new LocationWebModel
            {
                Id = _id,
                Role = _current?.Role ?? RoleCode.Honest,
                Location = _location,
                IsShow = !isShow,
            };
        }

        public GameWebModel Model()
        {
            var all = PlayersRepository.All.Where(p => p.IsPlay).Select(p => p.Map());

            var variants = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "Сомневается" } };
            variants.AddRange(PlayersRepository.All.Where(p => p.IsPlay && !p.IsVoted && p.Id != _id).Select(p =>
                new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                    Selected = p.Id == _current.VotePlayerId,
                }));

            return new GameWebModel
            {
                Id = _id,
                Current = _current?.Map() ?? new PlayerWebModel(),
                FirstName = _firstName,
                All = all,
                PlayersVariants = variants,
            };
        }
    }
}