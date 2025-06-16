using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Application.Exceptions;
using MediatR;


namespace CareerAdvisor.Application.UserProfiles.Commands
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand,Unit>
    {
        private readonly IUserProfileRepository _repository;

        public UpdateUserProfileCommandHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _repository.GetByUserIdAsync(request.UserId)??
                throw new NotFoundException("UserProfile");

            profile.CurrentJobTitle = request.Request.CurrentJobTitle;
            profile.YearsOfExperience = request.Request.YearsOfExperience;
            profile.EducationLevel = request.Request.EducationLevel;
            profile.Skills = request.Request.Skills;
            profile.Interests = request.Request.Interests;
            profile.Goals = request.Request.Goals;

            await _repository.UpdateAsync(profile);
            return Unit.Value;
        }
    }

}
