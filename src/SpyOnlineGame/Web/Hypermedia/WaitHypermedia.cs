using Htmx;
using SpyOnlineGame.Data;
using SpyOnlineGame.Models;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Web.Hypermedia;

public class WaitHypermedia(HttpRequest request, int id)
{
    private readonly Player? _current = PlayersRepository.Get(id);

    public bool IsHtmx => request.IsHtmx();

    public bool IsNotFound => _current is null;

    public WaitWebModel Model()
    {
        return new WaitWebModel
        {
            Id = id,
            Current = _current ?? new Player(),
            All = PlayersRepository.All,
        };
    }

    public bool HasOldData()
    {
        if (_current?.Data.IsNeedUpdate != true) return true;

        _current.Data.IsNeedUpdate = false;
        return false;
    }
}