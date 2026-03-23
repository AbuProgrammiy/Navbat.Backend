using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Navbat.API.Extensions;
using Navbat.Application.UseCases.Auth.Commands;

namespace Navbat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("send-code")]
        public async Task<IActionResult> SendCode(SendTemporaryCodeCommand request)
        {
            return (await _mediator.Send(request)).ToActionResult();
        }

        [HttpPost]
        [Route("verify-code")]
        public async Task<IActionResult> VerifyCode(VerifyTemporaryCodeCommand request)
        {
            return (await _mediator.Send(request)).ToActionResult();
        }


        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword()
        {
            // Not implemented yet
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            // Not implemented yet
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
