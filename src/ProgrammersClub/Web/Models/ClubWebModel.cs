using ProgrammersClub.Models;

namespace ProgrammersClub.Web.Models;

public class ClubWebModel
{
    public int Id { get; init; }
    public required Member Current { get; init; }
    public IEnumerable<Member> All { get; init; } =
        Array.Empty<Member>();
}