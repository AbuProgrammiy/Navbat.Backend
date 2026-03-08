using MediatR;
using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Service.Commands;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Service.Handlers.Commands
{
    public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, ServiceModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateServiceHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceModel> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            ServiceModel service = await _context.Services.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (service == null)
            {
                return null;
            }

            service.User = request.User;
            service.Name= request.Name;
            service.Description= request.Description;
            service.ImageUrl = request.ImageUrl;

            await _context.SaveChangesAsync();

            return service;
        }
    }
}
