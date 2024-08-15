using SpyOnlineGame.Models;

namespace SpyOnlineGame.Data;

public static class PlayersRepository
{
    private static List<Player> _players = new();
    private static int lastId = 1;

    public static IEnumerable<Player> All => _players;

    public static Player? Get(int id)
    {
        return All.FirstOrDefault(p => p.Id == id);
    }

    public static int Add(Player player)
    {
        player.Id = lastId++;
        _players.Add(player);
        isNeedAllUpdate();

        return player.Id;
    }

    private static void isNeedAllUpdate()
    {
        foreach (var each in All) each.Data.IsNeedUpdate = true;
    }
}