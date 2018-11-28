using MediatR;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Domain.Enumerations;
using Monuments.Manager.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetUserByIdQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(request.Id);

            return new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                JobTitle = user.JobTitle,
                Role = user.Role.ConvertTo<UserRoleDto>()
            };
        }
    }
}
