using MediatR;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Service.Queries
{
    public class GetAllServicesQuery:IRequest<List<ServiceModel>>
    {
    }
}
