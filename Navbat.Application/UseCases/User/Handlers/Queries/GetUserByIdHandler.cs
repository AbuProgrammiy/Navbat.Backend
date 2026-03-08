using MediatR;
using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.User.Queries;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.User.Handlers.Queries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IApplicationDbContext _context;

        public GetUserByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
