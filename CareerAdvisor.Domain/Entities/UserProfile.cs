using System;
using System.Collections.Generic;
using System.Linq;


namespace CareerAdvisor.Domain.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;

        // Background
        public string? CurrentJobTitle { get; set; }
        public int YearsOfExperience { get; set; }
        public string EducationLevel { get; set; } = string.Empty;

        // Skills, Interests, Goals (stored as JSON in PostgreSQL)
        public List<string> Skills { get; set; } = new();
        public List<string> Interests { get; set; } = new();
        public List<string> Goals { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation
        //public List<CareerRecommendation> Recommendations { get; set; } = new();
    }
}
