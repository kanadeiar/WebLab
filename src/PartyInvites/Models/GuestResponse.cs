using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models;

public class GuestResponse
{
    [Required(ErrorMessage = "Введите ваше имя")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Введите ваш адрес электронной почты")]
    [EmailAddress]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Пожалуйста, введите ваш телефон")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Пожалйста, определитесь, будете ли вы участвовать")]
    public bool? WillAttend { get; set; }
}