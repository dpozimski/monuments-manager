using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Common;
using Monuments.Manager.Domain.Enumerations;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class PromoteUserCommandHandler : IRequestHandler<PromoteUserCommand>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IApplicationContext _context;

        public PromoteUserCommandHandler(MonumentsDbContext dbContext,
                                         IApplicationContext context)
        {
            _dbContext = dbContext;
            _context = context;
        }

        public async Task<Unit> Handle(PromoteUserCommand request, CancellationToken cancellationToken)
        {
            var userContextEntity = await _dbContext.Users.FindAsync(_context.UserId);
            if(userContextEntity.Email == request.Email)
            {
                throw new MonumentsManagerAppException(ExceptionType.CannotPromoteYourself, "You can promote different user");
            }

            var userEntity = await _dbContext.Users.FirstOrDefaultAsync(s => s.Email == request.Email);
            if(userEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"There is no user with mail {request.Email}");
            }
            else if(userEntity.Role == UserRole.Administrator)
            {
                throw new MonumentsManagerAppException(ExceptionType.UserAlreadyPromoted, $"User {request.Email} is already promoted to Administrator role");
            }

            userEntity.Role = UserRole.Administrator;
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
