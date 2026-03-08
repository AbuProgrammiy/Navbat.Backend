using MediatR;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.User.Commands;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.User.Handlers.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserModel user = new UserModel
            {
                Id = Guid.NewGuid(),
                Age = request.Age,
                Name = request.Name,
                ChatId = request.ChatId,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
