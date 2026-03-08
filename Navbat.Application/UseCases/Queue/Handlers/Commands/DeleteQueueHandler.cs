using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Queue.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Handlers.Commands
{
    public class DeleteQueueHandler : IRequestHandler<DeleteQueueCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteQueueHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteQueueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Queues.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return false;

            _context.Queues.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
