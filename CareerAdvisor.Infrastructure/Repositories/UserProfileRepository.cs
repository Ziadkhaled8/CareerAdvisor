using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Domain.Entities;
using CareerAdvisor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CareerAdvisor.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(UserProfile profile, CancellationToken cancellationToken)
        {
            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync(cancellationToken);
            return profile.Id;
        }
        public async Task<bool> ExistsAsync(string userId)
        {
            return await _context.UserProfiles.AnyAsync(p => p.UserId == userId);
        }



        public async Task<UserProfile?> GetByUserIdAsync(string userId)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task UpdateAsync(UserProfile profile)
        {
            _context.UserProfiles.Update(profile);
            await _context.SaveChangesAsync();
        }
        public async Task<List<UserProfile>> GetAllAsync(string? jobTitle, int? minYearsExp, CancellationToken cancellationToken)
        {
            var query = _context.UserProfiles.AsQueryable();

            if (!string.IsNullOrEmpty(jobTitle))
                query = query.Where(p => p.CurrentJobTitle!.ToLower().Contains(jobTitle.ToLower()));

            if (minYearsExp.HasValue)
                query = query.Where(p => p.YearsOfExperience >= minYearsExp);

            return await query.ToListAsync(cancellationToken);
        }
        public async Task<(List<UserProfile> items, int totalCount)> GetUserProfilesAsync(string? search, int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var query = _context.UserProfiles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchLowerCase = search.ToLower();
                query = query.Where(u =>
                    u.CurrentJobTitle!.ToLower().Contains(searchLowerCase) ||
                    u.EducationLevel.ToLower().Contains(searchLowerCase) ||
                    u.User.Email!.ToLower().Contains(searchLowerCase));
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
            return new(items, totalCount);
        }
    }
}
