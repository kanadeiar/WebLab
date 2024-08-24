namespace ProgrammersClub.Models;

public class Member
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public SubjectCode? Subject { get; set; }
    public bool IsNeedUpdate { get; set; }
}