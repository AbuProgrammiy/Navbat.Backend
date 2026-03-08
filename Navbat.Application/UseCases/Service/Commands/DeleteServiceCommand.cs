using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Service.Commands
{
    public class DeleteServiceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
