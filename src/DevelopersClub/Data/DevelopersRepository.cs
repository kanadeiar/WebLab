using DevelopersClub.Models;

namespace DevelopersClub.Data;

public static class DevelopersRepository
{
    private static List<Developer> _developers = new();
    private static int _lastId = 1;
    
    public static IEnumerable<Developer> All => _developers;
    
    public static Developer? GetById(int id)
    {
        return All.FirstOrDefault(p => p.Id == id);
    }
    
    public static int Add(Developer player)
    {
        player.Id = _lastId++;
        _developers.Add(player);


        return player.Id;
    }
}