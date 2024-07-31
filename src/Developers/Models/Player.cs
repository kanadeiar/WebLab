namespace Developers.Models;

public class Player
{
    public string Name { get; set; }

    public bool IsReady { get; set; }

    public Player(string name)
    {
        Name = name;
    }
}