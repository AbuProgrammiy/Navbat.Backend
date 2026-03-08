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
    public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, ServiceModel>
    {
        private readonly IApplicationDbContext _context;

        public GetServiceByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceModel> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
