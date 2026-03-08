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
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteServiceHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            ServiceModel service = await _context.Services.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (service == null)
            {
                return false;
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return true;    
        }
    }
}
