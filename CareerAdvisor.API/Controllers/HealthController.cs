using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerAdvisor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealthStatus()
        {
            // Simple health check endpoint
            return Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow });
        }
        [Authorize]
        [HttpGet("secure")]
        public IActionResult SecureTest()
        {
            return Ok("You're authenticated!");
        }
    }
}
