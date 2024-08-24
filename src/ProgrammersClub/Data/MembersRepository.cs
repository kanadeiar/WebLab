using ProgrammersClub.Models;

namespace ProgrammersClub.Data;

public static class MembersRepository
{
    private static List<Member> _members = new();
    private static int _lastId = 1;

    public static IEnumerable<Member> All => _members;

    public static Member? GetById(int id)
    {
        return All.FirstOrDefault(p => p.Id == id);
    }

    public static int Add(Member player)
    {
        player.Id = _lastId++;
        _members.Add(player);
        UpNeedUpdate();
        return player.Id;
    }

    public static void UpNeedUpdate()
    {
        foreach (var each in All)
        {
            each.IsNeedUpdate = true;
        }
    }
}