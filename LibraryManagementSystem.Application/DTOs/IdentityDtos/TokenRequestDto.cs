using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs.IdentityDtos
{
    public record TokenRequestDto(string AccessToken, string RefreshToken);
}
