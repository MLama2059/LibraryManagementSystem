using LibraryManagementSystem.Application.DTOs.IdentityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto dto);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto dto);
        Task<AuthResponseDto> RefreshTokenAsync(TokenRequestDto dto);
    }
}
