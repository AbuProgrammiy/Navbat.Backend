
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Domain.Entities.Models
{
    public class TemporaryCodeModel
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public int Code { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
