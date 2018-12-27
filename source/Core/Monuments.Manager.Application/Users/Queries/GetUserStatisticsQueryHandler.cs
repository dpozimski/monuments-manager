using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Queries
{
    public class GetUserStatisticsQueryHandler : IRequestHandler<GetUserStatisticsQuery, UserStatisticsResult>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetUserStatisticsQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserStatisticsResult> Handle(GetUserStatisticsQuery request, CancellationToken cancellationToken)
        {
            var userEntity = await _dbContext.Users.FindAsync(request.UserId);

            if(userEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"User with id {request.UserId} does not exists");
            }

            var createdMonuments = await _dbContext.Monuments
                .Where(s => s.UserId == userEntity.Id)
                .CountAsync();

            var lastModifiedMonument = await _dbContext.Monuments
                .OrderByDescending(s => s.ModifiedDate)
                .FirstOrDefaultAsync(s => s.ModifiedBy == userEntity.Id.ToString());

            return new UserStatisticsResult()
            {
                CreatedMonuments = createdMonuments,
                LastLoggedIn = userEntity.LastLoggedIn,
                LastModifiedMonument = lastModifiedMonument?.Name,
                Role = userEntity.Role.ConvertTo<UserRoleDto>()
            };
        }
    }
}
