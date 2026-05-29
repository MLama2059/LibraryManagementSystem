using LibraryManagementSystem.Application.DTOs.IdentiyDtos;
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
    public class AuthController(UserManager<ApplicationUser> _userManager, IConfiguration _configuration) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
            {
                return BadRequest(new {Message = "Email address is already registered."});
            }

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var jwtSettings = _configuration.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryInMinutes"]!)),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }

            return Unauthorized(new { Message = "Invalid email or password credentials." });
        }
    }
}
