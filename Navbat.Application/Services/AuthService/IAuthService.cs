using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.Services.AuthService
{
    public interface IAuthService
    {
        public string GenerateToken(UserModel user);
    }
}
