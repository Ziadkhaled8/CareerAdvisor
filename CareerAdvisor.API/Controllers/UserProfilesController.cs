using AutoMapper;
using CareerAdvisor.Application.DTOs.Requests;
using CareerAdvisor.Application.UserProfiles.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareerAdvisor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            command.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            var profileId = await _mediator.Send(command);
            return Ok(new { profileId });
        }
    }
}
