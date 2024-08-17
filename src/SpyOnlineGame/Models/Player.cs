namespace SpyOnlineGame.Models;

public class Player
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool IsReady { get; set; }

    public PlayerViewData Data { get; init; } = new ();
}