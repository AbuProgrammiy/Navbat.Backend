using MediatR;
using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Application.UseCases.Auth.Commands;
using Navbat.Domain.Entities.Enums;
using Navbat.Domain.Entities.Models;
using Navbat.Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Auth.Handlers.Commands
{
    public class SendTemporaryCodeHandler : IRequestHandler<SendTemporaryCodeCommand, Response>
    {
        private readonly IApplicationDbContext _context;

        public SendTemporaryCodeHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(SendTemporaryCodeCommand request, CancellationToken cancellationToken)
        {
            int temporaryCode = new Random().Next(100000, 1000000);

            await _context.TemporaryCodes.AddAsync(new TemporaryCodeModel
            {
                PhoneNumber = request.PhoneNumber,
                Code = temporaryCode,
                CreatedAt = DateTime.UtcNow,
            });

            await _context.SaveChangesAsync();

            return new Response
            {
                IsSuccess = true,
                Status = StatusType.Success,
                Message = "Code sent"
            };
        }
    }
}
