using CareerAdvisor.Application.DTOs.UserProfile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAdvisor.Application.UserProfiles.Queries
{
    public class GetAllUserProfilesQuery : IRequest<List<UserProfileDto>>
    {
        public string? CurrentJobTitle { get; set; }
        public int? MinimumYearsOfExperience { get; set; }
    }

}
