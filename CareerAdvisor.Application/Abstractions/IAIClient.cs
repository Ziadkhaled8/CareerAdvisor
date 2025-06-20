using CareerAdvisor.Application.DTOs;
using CareerAdvisor.Application.DTOs.UserProfile;


namespace CareerAdvisor.Application.Abstractions
{
    public interface IAIClient
    {
        Task<RecommendationDto> GetCareerRecommendationsAsync(UserProfileDto profile);
    }
}
