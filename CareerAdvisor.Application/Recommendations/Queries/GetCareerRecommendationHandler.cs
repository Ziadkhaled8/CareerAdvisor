using AutoMapper;
using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Application.Abstractions;
using CareerAdvisor.Application.DTOs;
using MediatR;
using CareerAdvisor.Application.DTOs.UserProfile;
using CareerAdvisor.Application.Exceptions;

namespace CareerAdvisor.Application.Recommendations.Queries
{
    internal class GetCareerRecommendationHandler: IRequestHandler<GetCareerRecommendationQuery, RecommendationDto>
    {
        private readonly IUserProfileRepository _repo;
        private readonly IMapper _mapper;
        private readonly IAIClient _ai;

        public GetCareerRecommendationHandler(IUserProfileRepository repo, IMapper mapper, IAIClient ai)
        {
            _repo = repo;
            _mapper = mapper;
            _ai = ai;
        }

        public async Task<RecommendationDto> Handle(GetCareerRecommendationQuery request, CancellationToken cancellationToken)
        {
            var profile = await _repo.GetByUserIdAsync(request.UserId)
                ?? throw new NotFoundException("User profile not found.");

            var profileDto = _mapper.Map<UserProfileDto>(profile);
            return await _ai.GetCareerRecommendationsAsync(profileDto);
        }
    }
}
