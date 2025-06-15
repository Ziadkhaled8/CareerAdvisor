using CareerAdvisor.Domain.Entities;

namespace CareerAdvisor.Application.Abstractions.Repositories
{
    public interface IUserProfileRepository
    {
        Task<int> CreateAsync(UserProfile profile, CancellationToken cancellationToken);
    }
}
