using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Users.Extensions;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ICollection<UserDto>>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetUsersQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .Select(s => s.ToDto())
                .ToListAsync();
        }
    }
}
