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

    public bool IsShowRules => _current?.Data.IsShowRules ?? false;

    public bool IsGameStarted => 
        PlayersRepository.All.All(p => p is { IsReady: true, IsPlay: true });

    public WaitWebModel Model()
    {
        return new WaitWebModel
        {
            Id = id,
            Current = _current ?? new Player(),
            PlayPlayers = PlayersRepository.All.Where(p => p.IsPlay),
            WaitPlayers = PlayersRepository.All.Where(p => p.IsPlay == false),
            IsMayBeStart = PlayersRepository.All.Count() >= 3
                && PlayersRepository.All.All(x => x is { IsReady: true, IsPlay: false }),
        };
    }

    public bool HasOldData()
    {
        if (_current?.Data.IsNeedUpdate != true) return true;

        _current.Data.IsNeedUpdate = false;
        return false;
    }

    public void SwitchReady()
    {
        if (_current is null) return;

        _current.IsReady = !_current.IsReady;
        PlayersRepository.IsNeedAllUpdate();
    }

    public void SetName(string name)
    {
        if (_current is null || _current.Name == name) return;

        _current.Name = name;
        PlayersRepository.IsNeedAllUpdate();
    }

    public void SwitchShowRules()
    {
        if (_current is null) return;

        _current.Data.IsShowRules = !_current.Data.IsShowRules;
    }

    public void Kick(int playerId)
    {
        PlayersRepository.Remove(playerId);
    }

    public void Logout()
    {
        PlayersRepository.Remove(id);
    }

    public void Start()
    {
        foreach (var each in PlayersRepository.All)
        {
            each.IsPlay = true;
        }
        PlayersRepository.IsNeedAllUpdate();
    }
}