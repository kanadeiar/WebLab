using System.ComponentModel.DataAnnotations;

namespace ProgrammersClub.Models;

public class Member
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
    public string? Name { get; set; }
    public SubjectCode? Subject { get; set; }
}