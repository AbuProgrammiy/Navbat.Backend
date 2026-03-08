using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Queue.Commands;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Handlers.Commands
{
    public class UpdateQueueHandler : IRequestHandler<UpdateQueueCommand, QueueModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateQueueHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QueueModel> Handle(UpdateQueueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Queues.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return null;

            entity.User = request.User;
            entity.Service = request.Service;
            entity.Status = request.Status;

            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
