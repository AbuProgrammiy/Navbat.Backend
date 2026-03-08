using MediatR;
using Navbat.Domain.Entities.Enums;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Commands
{
    public class CreateQueueCommand : IRequest<QueueModel>
    {
        public UserModel User { get; set; }
        public ServiceModel Service { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public QueueStatus Status { get; set; } = QueueStatus.Waiting;
    }
}
