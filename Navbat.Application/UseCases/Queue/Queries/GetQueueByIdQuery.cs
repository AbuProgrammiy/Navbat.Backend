using MediatR;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Queries
{
    public class GetQueueByIdQuery : IRequest<QueueModel>
    {
        public Guid Id { get; set; }
    }
}
