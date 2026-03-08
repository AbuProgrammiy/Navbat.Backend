using MediatR;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.User.Commands
{
    public class CreateUserCommand : IRequest<UserModel>
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long ChatId { get; set; }
    }
}
