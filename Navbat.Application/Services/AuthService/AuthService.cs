using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Navbat.Domain.Entities.Models;

namespace Navbat.Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UserModel user)
        {
            // fixed list initializer
            var permissions = new List<int> { 1, 2, 2 };

            string permissionsJson = JsonSerializer.Serialize(permissions);

            var secret = _config["JWT:Secret"] ?? throw new InvalidOperationException("JWT:Secret is not configured");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            int expirePeriod = int.Parse(_config["JWT:Expire"] ?? "60");

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),

                // Use standard claim types for name/email
                new Claim(ClaimTypes.Name, user.FirstName ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),

                new Claim("permissions", permissionsJson)
            };

            var jwt = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            // Return raw token string (no prefix)
            string tokenString = new JwtSecurityTokenHandler().WriteToken(jwt);
            return tokenString;
        }
    }
}
