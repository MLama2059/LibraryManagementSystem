using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.DTOs.IdentiyDtos
{
    public record LoginDto(string Email, string Password);
}
