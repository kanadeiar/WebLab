using Microsoft.AspNetCore.Mvc.Rendering;

namespace Developers.Models.Voting;

public class VotingWebModel
{
    public int Id { get; set; }
    
    public IEnumerable<PlayerWebModel> Players { get; set; } = Array.Empty<PlayerWebModel>();

    public int SelectId { get; set; }

    public SelectList SelectPlayers { get; set; }

    public bool IsMayEnd { get; set; }
    public string Candidate { get; set; }
}