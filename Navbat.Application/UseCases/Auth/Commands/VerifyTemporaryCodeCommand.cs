using MediatR;
using Navbat.Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Auth.Commands
{
    public class VerifyTemporaryCodeCommand:IRequest<Response>
    {
        public string PhoneNumber { get; set; }
        public int Code { get; set; }
    }
}
