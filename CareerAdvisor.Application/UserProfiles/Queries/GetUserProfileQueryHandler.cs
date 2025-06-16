using AutoMapper;
using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Application.DTOs.UserProfile;
using CareerAdvisor.Application.Exceptions;
using MediatR;


namespace CareerAdvisor.Application.UserProfiles.Queries
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto?>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetUserProfileQueryHandler(IUserProfileRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserProfileDto?> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var profile = await _repository.GetByUserIdAsync(request.UserId)??
                throw new NotFoundException("User profile not found");

            return _mapper.Map<UserProfileDto>(profile);
        }
    }
}
