using MediatR;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Commands
{
    public class CreateServiceCategoryCommand : IRequest<ServiceCategoryModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
