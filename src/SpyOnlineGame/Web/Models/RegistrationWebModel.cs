using System.ComponentModel.DataAnnotations;
using SpyOnlineGame.Models;

namespace SpyOnlineGame.Web.Models
{
    public class RegistrationWebModel
    {
        [Display(Name = "Ваше имя:")]
        public string Name { get; set; }

        public Player Map()
        {
            return new Player
            {
                Name = Name,
            };
        }
    }
}