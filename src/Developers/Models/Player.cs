using System.ComponentModel.DataAnnotations;

namespace Developers.Models;

public class Player
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
    public string? Name { get; set; }

    public bool IsReady { get; set; }
    
    public RoleCode Role { get; set; }

    public int PlayerIdVote { get; set; }

    public bool Notify { get; set; }
}