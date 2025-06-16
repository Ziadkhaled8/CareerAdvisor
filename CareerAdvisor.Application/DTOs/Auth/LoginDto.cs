using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CareerAdvisor.Application.DTOs.Auth
{
    public class LoginDto
    {
        [EmailAddress, Required]
        public string Email { get; set; } = string.Empty;
        [PasswordPropertyText, Required]
        public string Password { get; set; } = string.Empty;
    }
}
