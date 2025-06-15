

namespace CareerAdvisor.Application.DTOs.Requests
{
    public class CreateUserProfileRequest
    {
        public string? CurrentJobTitle { get; set; }
        public int YearsOfExperience { get; set; }
        public string EducationLevel { get; set; } = string.Empty;
        public List<string> Skills { get; set; } = new();
        public List<string> Interests { get; set; } = new();
        public List<string> Goals { get; set; } = new();
    }
}
