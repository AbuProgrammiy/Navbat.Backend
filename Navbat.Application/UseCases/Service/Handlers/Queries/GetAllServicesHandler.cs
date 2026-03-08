using MediatR;
using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Service.Queries;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Service.Handlers.Queries
{
    public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, List<ServiceModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllServicesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceModel>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services.ToListAsync();
        }
    }
}
