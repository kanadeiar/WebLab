using Htmx;
using ProgrammersClub.Data;
using ProgrammersClub.Models;
using ProgrammersClub.Web.Models;

namespace ProgrammersClub.Web.Hypermedia;

public class ClubHypermedia
{
    private int _id;
    private readonly HttpRequest _request;
    private readonly Member? _current;

    public int Id => _id;

    public bool IsNotFound => _current is null;

    public bool IsHtmx => _request.IsHtmx();

    public ClubHypermedia(HttpRequest request, int id)
    {
        _request = request;
        _id = id;

        _current = MembersRepository.GetById(_id);
    }

    public ClubWebModel Model()
    {
        return new ClubWebModel
        {
            Id = _id,
            Current = _current ?? new Member(),
            All = MembersRepository.All,
            Selected = _current?.Subject,
        };
    }

    public void SelectSubject(SubjectCode? select)
    {
        if (_current != null)
        {
            _current.Subject = select;
            MembersRepository.UpNeedUpdate();
        }
    }

    public bool HasOldData()
    {
        if (_current?.IsNeedUpdate == false) return true;

        _current!.IsNeedUpdate = false;
        return false;
    }
}