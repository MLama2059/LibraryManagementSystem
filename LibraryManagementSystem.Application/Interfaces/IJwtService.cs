using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
