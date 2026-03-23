using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Domain.Entities.Enums
{
    public enum StatusType
    {
        Success = 200,
        NotFound = 404,
        BadRequest = 400,
        InternalError = 500
    }
}
