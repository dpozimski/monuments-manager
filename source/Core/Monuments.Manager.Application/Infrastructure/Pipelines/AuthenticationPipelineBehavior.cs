using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Common;
using Monuments.Manager.Domain.Enumerations;
using Monuments.Manager.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Infrastructure.Pipelines
{
    public class AuthenticationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IApplicationContext _context;

        public AuthenticationPipelineBehavior(MonumentsDbContext dbContext,
                                             IApplicationContext context)
        {
            _dbContext = dbContext;
            _context = context;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request.HasAttribute<AllowAnonymousAttribute>())
            {
                return await next();
            }

            var user = await _dbContext.Users.FindAsync(_context.UserId);

            if(user is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.AuthenticationFail, "You cannot execute this operation anonymously");
            }

            if(user.HasAttribute<AdministratorRoleRequirementAttribute>() && user.Role != UserRole.Administrator)
            {
                throw new MonumentsManagerAppException(ExceptionType.AuthenticationFail, "You need to be administrator to execute this operation");
            }

            return await next();
        }
    }
}
