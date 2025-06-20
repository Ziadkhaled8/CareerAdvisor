using CareerAdvisor.Domain.Entities;

namespace CareerAdvisor.Application.Abstractions.Repositories
{
    public interface IUserProfileRepository
    {
        Task<int> CreateAsync(UserProfile profile, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(string userId);
        Task<UserProfile?> GetByUserIdAsync(string userId);
        Task UpdateAsync(UserProfile profile);
        Task<List<UserProfile>> GetAllAsync(string? jobTitle, int? minYearsExp, CancellationToken cancellationToken);
        Task<(List<UserProfile> items, int totalCount)> GetUserProfilesAsync(string? search, int pageSize, int pageNumber, CancellationToken cancellationToken);

    }
}
