using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Application.Auth.LogIn;
using VaccinationSystem.Application.Auth.RegisterUser;

namespace VaccinationSystem.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginCommand command)
        {
            LoginResponseDto response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
