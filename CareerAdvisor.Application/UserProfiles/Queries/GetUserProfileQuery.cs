using CareerAdvisor.Application.DTOs.UserProfile;
using MediatR;

namespace CareerAdvisor.Application.UserProfiles.Queries
{
    public record GetUserProfileQuery(string UserId) : IRequest<UserProfileDto>;
}
