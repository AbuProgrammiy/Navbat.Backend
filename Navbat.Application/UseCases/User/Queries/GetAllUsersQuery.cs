using MediatR;
using Navbat.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.User.Queries
{
    public class GetAllUsersQuery:IRequest<List<UserModel>>
    {
    }
}
