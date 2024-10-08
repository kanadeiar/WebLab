﻿using System.Collections.Generic;
using System.Linq;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Data
{
    public static class PlayersRepository
    {
        private static List<Player> _players = new List<Player>();
        private static int _lastId = 1;

        public static IEnumerable<Player> All => _players;
        
        public static Player GetById(int id)
        {
            return All.FirstOrDefault(p => p.Id == id);
        }
        
        public static int Add(Player player)
        {
            player.Id = _lastId++;
            _players.Add(player);
            IsNeedAllUpdate();
            return player.Id;
        }

        public static void Remove(int id)
        {
            var deleted = GetById(id);
            if (deleted is null) return;
            IsNeedAllUpdate();
            _players.Remove(deleted);
        }

        public static void IsNeedAllUpdate()
        {
            foreach (var each in All) each.IsNeedUpdate = true;
        }
    }
}