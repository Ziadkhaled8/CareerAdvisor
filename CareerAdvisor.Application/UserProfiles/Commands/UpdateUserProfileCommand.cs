using CareerAdvisor.Application.DTOs.UserProfile;
using MediatR;


namespace CareerAdvisor.Application.UserProfiles.Commands
{
    public class UpdateUserProfileCommand(string userId, UpdateUserProfileRequest request) : IRequest<Unit>
    {
        public string UserId { get; set; } = userId;
        public UpdateUserProfileRequest Request { get; set; } = request;
    }
}
