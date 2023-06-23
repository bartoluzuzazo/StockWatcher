using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proj_APBD.Server.Interfaces;
using Proj_APBD.Server.Services;
using Proj_APBD.Shared.Models.DTOs;

namespace Proj_APBD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices _services;

        public AccountsController(IAccountServices services)
        {
            _services = services;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO dto)
        {
            var status = await _services.Register(dto.Username, dto.Password);
            if (status == 409)
            {
                return Conflict();
            }
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO dto)
        {
            var result = await _services.Login(dto.Username, dto.Password);
            if (result.Item1 == 401)
            {
                return Unauthorized();
            }
            return Ok(new JwtDTO()
            {
                Token = result.Item2,
                Ref = result.Item3
            });
        }

        [Authorize]
        [HttpGet("data")]
        public IActionResult GetUserData()
        {
            var claims = User.Claims.Select(c => new ClaimDTO(){Type = c.Type, Value = c.Value});
            return Ok(claims.ToList());
        }

    }
}
