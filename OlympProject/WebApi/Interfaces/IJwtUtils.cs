using OlympProject.WebApi.Models;

namespace OlympProject.WebApi.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateToken(Account account);
        public int? ValidateToken(string token);
    }
}
