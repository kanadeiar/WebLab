using DevelopersClub.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevelopersClub.Web.Models;

public class MeetingWebModel
{
    public int Id { get; init; }
    
    public required Developer Current { get; init; }
    
    public IEnumerable<Developer> All { get; init; } = 
        Array.Empty<Developer>();

    public SelectList Available { get; init; } = SubjectCodeExtensions.Available();
    
    public SubjectCode? Selected { get; init; }
}