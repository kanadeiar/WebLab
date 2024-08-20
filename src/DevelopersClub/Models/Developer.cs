namespace DevelopersClub.Models;

public class Developer
{
    public int Id { get; set; }
        
    public string? Name { get; set; }

    public SubjectCode? Subject { get; set; }
}