using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs.IdentityDtos
{
    public record AuthResponseDto(bool IsSuccess, string Token, string RefreshToken, string Message);
}
