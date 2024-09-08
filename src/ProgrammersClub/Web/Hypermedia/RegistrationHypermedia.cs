using Htmx;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProgrammersClub.Data;
using ProgrammersClub.Web.Models;

namespace ProgrammersClub.Web.Hypermedia;

public class RegistrationHypermedia
{
    private readonly HttpRequest _request;
    private readonly ModelStateDictionary _modelState;
    private readonly RegistrationWebModel _model;

    public int Id { get; set; }

    public bool IsHtmx => _request.IsHtmx();

    public bool IsInvalid => !_modelState.IsValid;

    public RegistrationHypermedia(HttpRequest request, ModelStateDictionary modelState, RegistrationWebModel model)
    {
        _model = model;
        _request = request;
        _modelState = modelState;

        model.Validate(_modelState);
    }

    public void RegisterNewMember()
    {
        var member = _model.Map();
        Id = MembersRepository.Add(member);
    }
}