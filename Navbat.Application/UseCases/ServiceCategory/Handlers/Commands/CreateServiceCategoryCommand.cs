using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Service.Commands;
using Navbat.Application.UseCases.ServiceCategory.Commands;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Handlers.Commands
{
    public class CreateServiceCategoryHandler : IRequestHandler<CreateServiceCategoryCommand, ServiceCategoryModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateServiceCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceCategoryModel> Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new ServiceCategoryModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description
            };

            await _context.ServiceCategories.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
