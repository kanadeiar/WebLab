using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProgrammersClub.Data;
using ProgrammersClub.Models;

namespace ProgrammersClub.Web.Models;

public class RegistrationWebModel
{
    [DisplayName("Имя")]
    [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
    [StringLength(30, ErrorMessage = "Имя должно быть короче 30 символов")]
    public string? Name { get; set; }

    public Member Map()
    {
        return new Member
        {
            Name = Name,
        };
    }

    public void Validate(ModelStateDictionary modelState)
    {
        if (MembersRepository.All.Any(x => x.Name == Name))
        {
            modelState.AddModelError("Name", "Такое имя уже занято");
        }
    }
}