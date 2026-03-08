using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Queue.Queries;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Handlers.Queries
{
    public class GetQueueByIdHandler : IRequestHandler<GetQueueByIdQuery, QueueModel>
    {
        private readonly IApplicationDbContext _context;

        public GetQueueByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QueueModel> Handle(GetQueueByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Queues.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
