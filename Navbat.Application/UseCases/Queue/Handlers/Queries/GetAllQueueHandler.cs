using MediatR;
using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Queue.Queries;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Queue.Handlers.Queries
{
    public class GetAllQueuesHandler : IRequestHandler<GetAllQueuesQuery, List<QueueModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllQueuesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QueueModel>> Handle(GetAllQueuesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Queues.ToListAsync(cancellationToken);
        }
    }
}
