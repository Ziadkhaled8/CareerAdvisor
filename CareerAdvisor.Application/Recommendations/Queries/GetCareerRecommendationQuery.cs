using CareerAdvisor.Application.DTOs;
using MediatR;


namespace CareerAdvisor.Application.Recommendations.Queries
{
    public class GetCareerRecommendationQuery : IRequest<RecommendationDto>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
