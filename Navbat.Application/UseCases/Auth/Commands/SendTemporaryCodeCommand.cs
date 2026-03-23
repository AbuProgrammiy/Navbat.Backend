using MediatR;
using Navbat.Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Auth.Commands
{
    public class SendTemporaryCodeCommand:IRequest<Response>
    {
        public string PhoneNumber {  get; set; }
    }
}
