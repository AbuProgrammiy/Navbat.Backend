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
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            UserModel user=await _context.Users.FirstOrDefaultAsync(x=>x.Id == request.Id);

            if (user == null) {
                return null;
            }

            user.Name=request.Name;
            user.Email=request.Email;
            user.PhoneNumber=request.PhoneNumber;
            user.ChatId=request.ChatId;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
