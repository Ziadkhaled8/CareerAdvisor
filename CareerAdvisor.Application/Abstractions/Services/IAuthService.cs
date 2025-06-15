using CareerAdvisor.Application.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace CareerAdvisor.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
