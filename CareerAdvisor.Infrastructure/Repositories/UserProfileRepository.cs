using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Domain.Entities;
using CareerAdvisor.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAdvisor.Infrastructure.Repositories
{
    public class UserProfileRepository:IUserProfileRepository
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
    }
}
