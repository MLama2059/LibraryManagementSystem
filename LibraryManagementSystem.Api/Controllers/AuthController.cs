using LibraryManagementSystem.Application.DTOs.IdentityDtos;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Errors = result.Errors });
            }

            return Ok(new { Message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (!result.IsSuccess)
            {
                return Unauthorized(new { Message = result.Message });
            }

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenRequestDto dto)
        {
            var result = await _authService.RefreshTokenAsync(dto);
            if (!result.IsSuccess)
            {
                return Unauthorized(new { Message = result.Message });
            }
            return Ok(result);
        }
    }
}
