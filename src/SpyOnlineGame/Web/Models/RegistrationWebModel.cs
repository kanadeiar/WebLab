using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class RegistrationWebModel
    {
        [Display(Name = "Ваше имя:")]
        [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
        [StringLength(30, ErrorMessage = "Имя должно быть короче 30 символов")]
        public string Name { get; set; }

        public Player Map()
        {
            return new Player
            {
                Name = Name,
            };
        }

        public void Validate(ModelStateDictionary modelState)
        { }
    }
}