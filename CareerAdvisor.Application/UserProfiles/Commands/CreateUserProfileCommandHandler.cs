using AutoMapper;
using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAdvisor.Application.UserProfiles.Commands
{
    internal class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, int>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserProfileCommandHandler(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = _mapper.Map<UserProfile>(request);
            return await _repository.CreateAsync(profile, cancellationToken);
        }
    }
}
