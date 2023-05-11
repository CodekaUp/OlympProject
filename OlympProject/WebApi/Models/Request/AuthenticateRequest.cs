using System.ComponentModel.DataAnnotations;

namespace OlympProject.WebApi.Models.Request
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
