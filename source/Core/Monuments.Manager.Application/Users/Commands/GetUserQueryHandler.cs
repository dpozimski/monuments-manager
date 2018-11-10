using MediatR;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Domain.Enumerations;
using Monuments.Manager.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly MonumentsDbContext _monumentDbContext;

        public GetUserQueryHandler(MonumentsDbContext monumentDbContext)
        {
            _monumentDbContext = monumentDbContext;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _monumentDbContext.Users.FindAsync(request.Id);

            return new UserDto()
            {
                Username = user.Username,
                Role = (UserRoleDto)Enum.Parse(typeof(UserRole), user.Role.ToString())
            };
        }
    }
}
