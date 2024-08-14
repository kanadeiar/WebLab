using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models;

public class WaitWebModel
{
    public int Id { get; init; }

    public required Player Current { get; init; }

    public IEnumerable<Player> All { get; init; } = Array.Empty<Player>();
}