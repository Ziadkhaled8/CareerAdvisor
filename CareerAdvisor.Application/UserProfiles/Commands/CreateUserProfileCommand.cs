using MediatR;

namespace CareerAdvisor.Application.UserProfiles.Commands
{
    public class CreateUserProfileCommand : IRequest<int>
    {
        public string UserId { get; set; } = string.Empty;
        public string? CurrentJobTitle { get; set; }
        public int YearsOfExperience { get; set; }
        public string EducationLevel { get; set; } = string.Empty;
        public List<string> Skills { get; set; } = new();
        public List<string> Interests { get; set; } = new();
        public List<string> Goals { get; set; } = new();
    }
}
