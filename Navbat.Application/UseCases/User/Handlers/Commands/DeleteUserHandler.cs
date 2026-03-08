using MediatR;
using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.User.Commands;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.User.Handlers.Commands
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private IApplicationDbContext _context;

        public DeleteUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            UserModel user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
