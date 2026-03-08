using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.User.Commands
{
    public class DeleteUserCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
