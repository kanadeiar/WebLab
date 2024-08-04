using Developers.Models;

namespace Developers.Data;

public class PlayersRepository
{
    private static List<Player> players = new();
    private static int lastId = 1;

    public static IEnumerable<Player> Players => players;

    public static Player? Get(int id)
    {
        return Players.FirstOrDefault(p => p.Id == id);
    }

    public static void Add(Player player)
    {
        player.Id = lastId;
        lastId++;
        players.Add(player);
        Notify();
    }

    public static void Remove(int id)
    {
        var player = Players.FirstOrDefault(p => p.Id == id);
        if (player != null)
        {
            players.Remove(player);
            Notify();
        }
    }

    public static void Notify()
    {
        foreach (var each in Players)
        {
            each.Notify = true;
        }
    }
}