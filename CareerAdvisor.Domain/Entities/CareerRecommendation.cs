using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAdvisor.Domain.Entities
{
    public class CareerRecommendation
    {
        public int Id { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;

        public List<string> Recommendations { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
