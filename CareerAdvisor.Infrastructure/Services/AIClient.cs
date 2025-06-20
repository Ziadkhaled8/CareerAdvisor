using CareerAdvisor.Application.Abstractions;
using CareerAdvisor.Application.DTOs;
using CareerAdvisor.Application.DTOs.UserProfile;
using System.Net.Http.Json;


namespace CareerAdvisor.Infrastructure.Services
{
    internal class AIClient : IAIClient
    {
        private readonly HttpClient _httpClient;

        public AIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<RecommendationDto> GetCareerRecommendationsAsync(UserProfileDto profile)
        {
            var response = await _httpClient.PostAsJsonAsync("/recommendations", new
            {
                skills = profile.Skills,
                interests = profile.Interests,
                goals = profile.Goals
            });

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<RecommendationDto>();
            return result!;
        }
    }
}
