using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Domain.Entities.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long ChatId { get; set; }
    }
}
