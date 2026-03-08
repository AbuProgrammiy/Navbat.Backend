using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Commands
{
    public class DeleteQueueCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
