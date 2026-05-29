using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs.IdentiyDtos
{
    public record RegisterDto(string Email, string Password, string FullName);
}
