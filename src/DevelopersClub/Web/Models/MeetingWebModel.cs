using DevelopersClub.Models;

namespace DevelopersClub.Web.Models;

public class MeetingWebModel
{
    public int Id { get; init; }
    
    public required Developer Current { get; init; }

    public IEnumerable<Developer> All { get; init; } = Array.Empty<Developer>();
}