using Developers.Models;

namespace Developers.Data;

public class PlayersRepository
{
    private static List<Player> players = new();

    public static IEnumerable<Player> Players => players;

    public static Player? Get(string name)
    {
        return players.FirstOrDefault(p => p.Name == name);
    }

    public static void Add(Player response)
    {
        players.Add(response);
    }
}