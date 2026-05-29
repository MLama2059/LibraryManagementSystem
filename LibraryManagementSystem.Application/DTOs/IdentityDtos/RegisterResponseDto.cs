using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs.IdentityDtos
{
    public record RegisterResponseDto(bool IsSuccess, string[] Errors);
}
