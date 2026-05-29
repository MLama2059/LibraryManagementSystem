using LibraryManagementSystem.Application.DTOs.IdentityDtos;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Services
{
    public class AuthService(UserManager<ApplicationUser> _userManager, IJwtService _jwtService) : IAuthService
    {
        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
            {
                return new RegisterResponseDto(false, ["Email address is already registered."]);
            }

            var newUser = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (!result.Succeeded)
            {
                return new RegisterResponseDto(false, result.Errors.Select(e => e.Description).ToArray());
            }

            return new RegisterResponseDto(true, Array.Empty<string>());
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
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

                var accessToken = _jwtService.GenerateAccessToken(claims);
                var refreshToken = _jwtService.GenerateRefreshToken();

                // Save refresh token details down to the user row
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _userManager.UpdateAsync(user);

                return new AuthResponseDto(true, accessToken, refreshToken, "Login successful.");
            }

            return new AuthResponseDto(false, string.Empty, string.Empty, "Invalid email or password.");
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(TokenRequestDto dto)
        {
            var principal = _jwtService.GetPrincipalFromExpiredToken(dto.AccessToken);
            if (principal == null)
            {
                return new AuthResponseDto(false, string.Empty, string.Empty, "Invalid access token.");
            }

            string email = principal.Identity!.Name!;
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || user.RefreshToken != dto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return new AuthResponseDto(false, string.Empty, string.Empty, "Invalid or expired refresh token request.");
            }

            var newAccessToken = _jwtService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);
            
            return new AuthResponseDto(true, newAccessToken, newRefreshToken, "Token refreshed successfully.");
        }
    }
}
