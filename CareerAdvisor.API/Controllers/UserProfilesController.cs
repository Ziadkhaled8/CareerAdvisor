using AutoMapper;
using CareerAdvisor.Application.DTOs;
using CareerAdvisor.Application.DTOs.Requests;
using CareerAdvisor.Application.DTOs.UserProfile;
using CareerAdvisor.Application.UserProfiles.Commands;
using CareerAdvisor.Application.UserProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareerAdvisor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserProfileRequest request)
        {
            var command = _mapper.Map<CreateUserProfileCommand>(request);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized();
            command.UserId = userId;

            var profileId = await _mediator.Send(command);
            return Ok(new { profileId });
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var result = await _mediator.Send(new GetUserProfileQuery(userId));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMyProfile(UpdateUserProfileRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var result = await _mediator.Send(new UpdateUserProfileCommand(userId, request));
            return Ok(result);
        }

        [HttpGet("userprofiles")]
        public async Task<IActionResult> GetAllUserProfiles([FromQuery] string? jobTitle, [FromQuery] int? minYears)
        {
            var result = await _mediator.Send(new GetAllUserProfilesQuery
            {
                CurrentJobTitle = jobTitle,
                MinimumYearsOfExperience = minYears
            });

            return Ok(result);
        }

        [HttpGet("admin/userprofiles")]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PagedResult<UserProfileDto>>> GetAllUserProfiles([FromQuery] GetUserProfilesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
