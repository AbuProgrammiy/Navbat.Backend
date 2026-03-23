using Microsoft.AspNetCore.Mvc;
using Navbat.Domain.Entities.Enums;
using Navbat.Domain.Entities.Views;

namespace Navbat.API.Extensions
{
    public static class ResponseExtensions
    {
        public static IActionResult ToActionResult(this Response response)
        {
            if (response.IsSuccess)
                return new OkObjectResult(response);

            return response.Status switch
            {
                StatusType.NotFound => new NotFoundObjectResult(response),
                StatusType.BadRequest => new BadRequestObjectResult(response),
                //ErrorType.Unauthorized => new UnauthorizedObjectResult(response.Message),
                //ErrorType.Forbidden => new ForbidResult(),
                //ErrorType.Conflict => new ConflictObjectResult(response.Message),
                _ => new ObjectResult(response.Message) { StatusCode = 500 }
            };
        }
    }
}
