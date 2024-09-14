using System;

namespace SpyOnlineGame.Models
{
    public static class LocationsSource
    {
        private static Random _rand = new Random();

        private static string[] _locations =
        {
            "Банк",
            "Казино",
            "Больница",
            "Офис",
            "Казино",
        };

        public static string GetRandomLocation()
        {
            var locationNum = _rand.Next(_locations.Length);

            return _locations[locationNum];
        }
    }
}