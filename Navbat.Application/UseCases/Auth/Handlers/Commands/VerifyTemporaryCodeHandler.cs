using MediatR;
using Microsoft.EntityFrameworkCore;
using Navbat.Application.Abstractions;
using Navbat.Application.Services.AuthService;
using Navbat.Application.UseCases.Auth.Commands;
using Navbat.Domain.Entities.Enums;
using Navbat.Domain.Entities.Models;
using Navbat.Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navbat.Application.UseCases.Auth.Handlers.Commands
{
    public class VerifyTemporaryCodeHandler : IRequestHandler<VerifyTemporaryCodeCommand, Response>
    {
        private readonly IApplicationDbContext _context;
        private readonly IAuthService _authService;

        public VerifyTemporaryCodeHandler(IApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<Response> Handle(VerifyTemporaryCodeCommand request, CancellationToken cancellationToken)
        {
            TemporaryCodeModel codeModel = await _context.TemporaryCodes
                .Where(x => x.PhoneNumber == request.PhoneNumber)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();

            if (codeModel == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Status = StatusType.NotFound,
                    Message = "PhoneNumber is not found"
                };
            }

            if (request.Code != codeModel.Code)
            {
                return new Response
                {
                    IsSuccess = false,
                    Status = StatusType.BadRequest,
                    Message = "Not Matched"
                };
            }

            UserModel user = _context.Users.FirstOrDefault(x => x.PhoneNumber == request.PhoneNumber);
            if (user == null)
            {
                user = new UserModel
                {
                    Id = Guid.NewGuid(),
                    PhoneNumber = request.PhoneNumber,

                    // Static naming
                    FirstName = "Undetermined",
                    LastName = "Undetermined",
                    Age = 0,
                    Email = "Undetermined",
                    ChatId = 0
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            string token = _authService.GenerateToken(user);

            return new Response<string>
            {
                IsSuccess = true,
                Status = StatusType.Success,
                Message = "Verified",
                Data = token
            };
        }
    }
}
