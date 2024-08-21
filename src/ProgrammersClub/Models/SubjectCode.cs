using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProgrammersClub.Models;

public enum SubjectCode { Csharp, C, Cpp, Java, JavaScript }

public static class SubjectCodeExtensions
{
    private static IEnumerable<Tuple<SubjectCode, string>> descriptions()
    {
        yield return new(SubjectCode.Csharp, "C#");
        yield return new(SubjectCode.C, "C");
        yield return new(SubjectCode.Cpp, "C++");
        yield return new(SubjectCode.Java, "Java");
        yield return new(SubjectCode.JavaScript, "JavaScript");
    }
    
    public static SelectList Available()
    {
        var items = descriptions()
            .Select(x => new { value = x.Item1, text = x.Item2 });
        return new SelectList(items, "value", "text");
    }

    public static string Description(this SubjectCode? subject)
    {
        return descriptions()
            .FirstOrDefault(x => x.Item1 == subject)?.Item2 ?? "Не выбрано";
    }
}
