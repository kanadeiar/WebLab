using SpyOnlineGame.Data;
using SpyOnlineGame.Models;
using SpyOnlineGame.Web.Models;

namespace SpyOnlineGame.Web.Services
{
    public class EndWebService
    {
        private readonly Player _current;

        public EndWebService(int id)
        {
            _current = PlayersRepository.GetById(id);
        }

        public EndWebModel Model() =>
            EndWebModel.Create(_current);
    }
}