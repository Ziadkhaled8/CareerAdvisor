using AutoMapper;
using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Application.DTOs.UserProfile;
using CareerAdvisor.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAdvisor.Application.UserProfiles.Queries
{
    public class GetUserProfilesQueryHandler : IRequestHandler<GetUserProfilesQuery, PagedResult<UserProfileDto>>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetUserProfilesQueryHandler(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<UserProfileDto>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _repository.GetUserProfilesAsync(request.Search, request.PageSize, request.PageNumber, cancellationToken);
            var mappedItems = _mapper.Map<List<UserProfileDto>>(items);

            return new PagedResult<UserProfileDto>(mappedItems, totalCount, request.PageNumber, request.PageSize);
        }
    }
}
