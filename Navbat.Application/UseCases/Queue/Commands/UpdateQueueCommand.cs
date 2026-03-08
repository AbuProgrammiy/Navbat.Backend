using MediatR;
using Navbat.Domain.Entities.Enums;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Commands
{
    public class UpdateQueueCommand : IRequest<QueueModel>
    {
        public Guid Id { get; set; }
        public UserModel User { get; set; }
        public ServiceModel Service { get; set; }
        public QueueStatus Status { get; set; }
    }
}
