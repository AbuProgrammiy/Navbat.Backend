using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.ServiceCategory.Queries;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Handlers.Queries
{
    public class GetServiceCategoryByIdHandler : IRequestHandler<GetServiceCategoryByIdQuery, ServiceCategoryModel>
    {
        private readonly IApplicationDbContext _context;

        public GetServiceCategoryByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceCategoryModel> Handle(GetServiceCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.ServiceCategories.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
