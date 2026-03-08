using MediatR;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Service.Commands
{
    public class CreateServiceCommand : IRequest<ServiceModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public UserModel User { get; set; }
    }
}
