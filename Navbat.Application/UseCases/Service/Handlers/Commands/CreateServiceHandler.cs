using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Service.Commands;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Service.Handlers.Commands
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, ServiceModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateServiceHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceModel> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            ServiceModel service = new ServiceModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            };

            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();

            return service;
        }
    }
}
