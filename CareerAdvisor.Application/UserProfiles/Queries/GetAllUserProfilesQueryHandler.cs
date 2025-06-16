using AutoMapper;
using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Application.DTOs.UserProfile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAdvisor.Application.UserProfiles.Queries
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, List<UserProfileDto>>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUserProfilesQueryHandler(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserProfileDto>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _repository.GetAllAsync(
                request.CurrentJobTitle, request.MinimumYearsOfExperience, cancellationToken
            );

            return _mapper.Map<List<UserProfileDto>>(profiles);
        }
    }

}
