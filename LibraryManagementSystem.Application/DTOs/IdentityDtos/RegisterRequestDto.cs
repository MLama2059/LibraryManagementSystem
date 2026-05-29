using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs.IdentityDtos
{
    public record RegisterRequestDto(string Email, string Password, string FullName);
}
