using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs.IdentityDtos
{
    public record LoginRequestDto(string Email, string Password);
}
