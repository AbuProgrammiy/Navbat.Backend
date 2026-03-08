using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Queue.Commands;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Handlers.Commands
{
    public class CreateQueueHandler : IRequestHandler<CreateQueueCommand, QueueModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateQueueHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QueueModel> Handle(CreateQueueCommand request, CancellationToken cancellationToken)
        {
            var entity = new QueueModel
            {
                Id = Guid.NewGuid(),
                User = request.User,
                Service = request.Service,
                CreatedAt = request.CreatedAt,
                Status = request.Status
            };

            await _context.Queues.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
