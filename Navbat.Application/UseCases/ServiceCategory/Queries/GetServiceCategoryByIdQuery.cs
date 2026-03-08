using MediatR;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Queries
{
    public class GetServiceCategoryByIdQuery : IRequest<ServiceCategoryModel>
    {
        public Guid Id { get; set; }
    }
}
