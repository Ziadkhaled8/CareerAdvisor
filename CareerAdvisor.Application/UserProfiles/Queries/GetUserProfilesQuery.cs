using CareerAdvisor.Application.DTOs;
using CareerAdvisor.Application.DTOs.UserProfile;
using MediatR;


namespace CareerAdvisor.Application.UserProfiles.Queries
{
    public class GetUserProfilesQuery : IRequest<PagedResult<UserProfileDto>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
