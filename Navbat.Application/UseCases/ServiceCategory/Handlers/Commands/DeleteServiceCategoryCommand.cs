using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.ServiceCategory.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Handlers.Commands
{
    public class DeleteServiceCategoryHandler : IRequestHandler<DeleteServiceCategoryCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteServiceCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ServiceCategories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return false;

            _context.ServiceCategories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
