namespace SpyOnlineGame.Models;

public class Player
{
    public int Id { get; set; }

    public string? Name { get; init; }

    public PlayerData Data { get; init; } = new ();
}