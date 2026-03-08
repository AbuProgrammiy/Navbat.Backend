using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Navbat.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public bool SignUp()
        {
            return true;
        }

        [HttpGet]
        public bool LogIn()
        {
            return true;
        }

        [HttpGet]
        public bool ForgotPassword()
        {
            return true;
        }

        [HttpGet]
        public bool RefreshToken()
        {
            return true;
        }
    }
}
