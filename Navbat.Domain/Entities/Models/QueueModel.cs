using Navbat.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Domain.Entities.Models
{
    public class QueueModel
    {
        public Guid Id { get; set; }
        public UserModel User { get; set; }
        public ServiceModel Service { get; set; }
        public DateTime CreatedAt { get; set; }
        public QueueStatus Status { get; set; }
    }
}
