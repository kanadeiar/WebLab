﻿using System;
using System.Linq;
using System.Web;
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

        public bool IsNeedInit => 
            string.IsNullOrEmpty(_location) && PlayersRepository.All.Any(p => p.IsPlay);

        public GameHypermedia(HttpRequestBase request, int id)
        {
            _request = request;
            _id = id;

            _current = PlayersRepository.GetById(_id);
        }

        public void Init()
        {
            var all = PlayersRepository.All.ToArray();
            var firstNum = _rand.Next(all.Length);
            _firstName = all[firstNum].Name;
            _location = LocationsSource.GetRandomLocation();
        }

        public GameWebModel Model()
        {
            return new GameWebModel
            {
                Id = _id,
                Current = _current ?? new Player(),
                Location = _location,
                FirstName = _firstName,
            };
        }
    }
}