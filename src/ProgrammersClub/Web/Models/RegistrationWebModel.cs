using System.ComponentModel.DataAnnotations;
using ProgrammersClub.Models;

namespace ProgrammersClub.Web.Models;

public class RegistrationWebModel
{
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
}