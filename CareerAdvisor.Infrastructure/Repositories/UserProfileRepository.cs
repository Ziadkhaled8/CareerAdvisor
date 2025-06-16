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
    }
}
