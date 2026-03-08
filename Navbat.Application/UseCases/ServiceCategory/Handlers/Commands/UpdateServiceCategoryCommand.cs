using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.ServiceCategory.Commands;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Handlers.Commands
{
    public class UpdateServiceCategoryHandler : IRequestHandler<UpdateServiceCategoryCommand, ServiceCategoryModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateServiceCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceCategoryModel> Handle(UpdateServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ServiceCategories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return null;

            entity.Name = request.Name;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
