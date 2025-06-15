

using Microsoft.AspNetCore.Identity;

namespace CareerAdvisor.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public UserProfile? Profile { get; set; }
    }
}
