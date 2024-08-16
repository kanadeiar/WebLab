namespace SpyOnlineGame.Models;

public class Player
{
    public int Id { get; set; }

    public string? Name { get; init; }

    public PlayerViewData Data { get; init; } = new ();
}