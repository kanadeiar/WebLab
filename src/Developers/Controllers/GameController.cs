using Developers.Data;
using Developers.Models;
using Developers.Models.Voting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Developers.Controllers;

public class GameController : Controller
{
    private IEnumerable<string> _locations = new[]
    {
        "База террористов",
        "Банк",
        "Больница",
        "Воинская часть",
        "Кирпичный завод",
        "Киностудия",
        "Казино",
        "Овощебаза",
        "Океанский лайнер",
        "Орбитальная станция",
        "Отель",
        "Пассажирский поезд",
        "Пиратский корабль",
        "Пляж",
        "Посольство",
        "Ресторан",
        "Самолет",
        "Театр",
        "Университет",
        "Цирк",
        "Школа",
        "Ясли",
    };

    public static RoleCode WiningTeam;
    public static GameCode Code = GameCode.Default;

    private static string _selectedLocation;
    private static string _firstName;
    
    private static Random _random = new();
    
    public IActionResult Index(int id)
    {
        if (Code == GameCode.Default)
        {
            var players = PlayersRepository.Players.ToArray();
            foreach (var each in players)
            {
                each.Role = RoleCode.Honest;
            }
            
            var spyNum = _random.Next(players.Length);
            players[spyNum].Role = RoleCode.Spy;

            var locations = _locations.ToArray();
            var locationNum = _random.Next(locations.Length);
            _selectedLocation = locations[locationNum];

            var firstNum = _random.Next(players.Length);
            _firstName = players[firstNum].Name;

            Code = GameCode.GameStart;
        }

        var player = PlayersRepository.Get(id);
        player.Notify = true;
        
        ViewBag.Id = id;
        ViewBag.Name = player?.Name;
        ViewBag.IsShow = false;
        ViewBag.FirstName = _firstName;
        
        return View();
    }

    public IActionResult Location(int id, bool isShow = false)
    {
        var player = PlayersRepository.Get(id);
        ViewBag.Id = id;
        ViewBag.IsShow = !isShow;
        ViewBag.Role = player.Role;
        ViewBag.Location = _selectedLocation;
        
        return PartialView("Partial/LocationPartial");
    }

    public IActionResult ShowRules(bool isShowRules)
    {
        ViewBag.IsShowRules = !isShowRules;
        ViewBag.Locations = _locations.ToArray();

        return PartialView("Partial/RulesPartial");
    }

    public IActionResult Voting(int id)
    {
        var players = PlayersRepository.Players;
        var player = PlayersRepository.Get(id);
        if (player is null || player.Notify == false) return NoContent();
        player.Notify = false;

        var models = players.Select(x => new PlayerWebModel
        {
            Id = x.Id,
            Name = x.Name,
            Vote = players?.FirstOrDefault(p => p.Id == x.PlayerIdVote)?.Name ?? "Сомневаюсь",
        });
        var model = new VotingWebModel
        {
            Id = id,
            Players = models,
            SelectId = player.PlayerIdVote,
            SelectPlayers = new SelectList(players.Where(x => x.Id != id), "Id", "Name"),
        };

        var votes = players.ToDictionary(x => x.Id, x => players.Count(p => p.PlayerIdVote == x.Id));
        var candidate = votes.FirstOrDefault(x => x.Value >= 2);
        if (candidate.Key > 0)
        {
            model.IsMayEnd = true;
            model.Candidate = players.FirstOrDefault(x => x.Id == candidate.Key)?.Name;
        }

        if (Code == GameCode.GameEnd)
        {
            Response.Headers.Add("HX-Redirect", Url.Action("Index", "End", new { id }));
        }

        return PartialView("Partial/VotingPartial", model);
    }

    public IActionResult Vote(int id, int selectId = 0)
    {
        var player = PlayersRepository.Get(id);
        player.PlayerIdVote = selectId;
        PlayersRepository.Notify();

        return Voting(id);
    }

    [HttpPost]
    public IActionResult GameEnd()
    {
        if (Code == GameCode.GameStart)
        {
            var players = PlayersRepository.Players;
            var votes = players.ToDictionary(x => x, x => players.Count(p => p.PlayerIdVote == x.Id));
            var candidate = votes.FirstOrDefault(x => x.Value >= 2);
            if (candidate.Key.Role == RoleCode.Honest)
            {
                WiningTeam = RoleCode.Spy;
            }

            Code = GameCode.GameEnd;

            PlayersRepository.Notify();
        }

        return NoContent();
    }
}