using Navbat.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Domain.Entities.Views
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public StatusType Status { get; set; }
        public string Message { get; set; }
    }

    public class Response<T>:Response
    {
        public T Data { get; set; }
    }
}
