using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Domain.Entities.Models
{
    public class ServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public UserModel User { get; set; }
    }
}
