using MediatR;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Domain.Enumerations;
using Monuments.Manager.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetUserQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(request.Id);

            return new UserDto()
            {
                Username = user.Username,
                JobTitle = user.JobTitle,
                Role = (UserRoleDto)Enum.Parse(typeof(UserRole), user.Role.ToString())
            };
        }
    }
}
