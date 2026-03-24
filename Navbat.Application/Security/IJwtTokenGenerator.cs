using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Navbat.Application.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}