using MediatR;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Commands
{
    public class UpdateServiceCategoryCommand : IRequest<ServiceCategoryModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
