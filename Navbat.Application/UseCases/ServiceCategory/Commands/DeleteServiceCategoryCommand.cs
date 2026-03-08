using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.ServiceCategory.Commands
{
    public class DeleteServiceCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
