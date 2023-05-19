using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.WebApi.Interfaces
{
    public interface IAccountService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model);
        public Account GetById(int id);
        public void Register(RegisterRequest model);
    }
}
