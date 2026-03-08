using MediatR;
using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.ServiceCategory.Queries;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Handlers.Queries
{
    public class GetAllServiceCategoriesHandler : IRequestHandler<GetAllServiceCategoriesQuery, List<ServiceCategoryModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllServiceCategoriesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceCategoryModel>> Handle(GetAllServiceCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.ServiceCategories.ToListAsync(cancellationToken);
        }
    }
}
