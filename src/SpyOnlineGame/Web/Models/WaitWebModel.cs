using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models;

public class WaitWebModel
{
    public int Id { get; init; }

    public required Player Current { get; init; }

    public IEnumerable<Player> PlayPlayers { get; init; } = Array.Empty<Player>();

    public IEnumerable<Player> WaitPlayers { get; init; } = Array.Empty<Player>();

    public bool IsMayBeStart { get; init; }
}