using CareerAdvisor.Application.DTOs;
using MediatR;

namespace CareerAdvisor.Application.UserProfiles.Queries
{
    public record GetUserProfileQuery(string UserId) : IRequest<UserProfileDto>;
}
