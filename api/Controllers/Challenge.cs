using coding_challenge.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace coding_challenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class Challenge(IMockTaskService mockTaskService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = mockTaskService.GetAll();
            return result.IsFailure
                ? BadRequest(new { error = result.Error })
                : Ok(result.Value);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = mockTaskService.GetById(id);
            return result.IsFailure
                ? NotFound(new { error = result.Error })
                : Ok(result.Value);
        }
    }
}
