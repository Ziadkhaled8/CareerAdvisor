
namespace CareerAdvisor.Application.DTOs.UserProfile
{
    public class UpdateUserProfileRequest
    {
        public string CurrentJobTitle { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string EducationLevel { get; set; } = string.Empty;
        public List<string> Skills { get; set; } = new();
        public List<string> Interests { get; set; } = new();
        public List<string> Goals { get; set; } = new();
    }
}
