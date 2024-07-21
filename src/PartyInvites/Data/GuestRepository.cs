using PartyInvites.Models;

namespace PartyInvites.Data;

public class GuestRepository
{
    private static List<GuestResponse> _responses = new();

    public static IEnumerable<GuestResponse> Responses => _responses;

    public static void AddResponse(GuestResponse response)
    {
        Console.WriteLine(response);

        _responses.Add(response);
    }
}