using MediatR;
using Monuments.Manager.Application.Email;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Common;
using Monuments.Manager.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPasswordEncryptor _passwordEncryptor;
        private readonly IEmailSender _emailSender;
        private readonly IApplicationContext _applicationContext;

        public UpdateUserCommandHandler(MonumentsDbContext dbContext,
                                        IPasswordEncryptor passwordEncryptor,
                                        IEmailSender emailSender,
                                        IApplicationContext applicationContext)
        {
            _dbContext = dbContext;
            _passwordEncryptor = passwordEncryptor;
            _emailSender = emailSender;
            _applicationContext = applicationContext;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FindAsync(request.Id);

            if (entity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type UserEntity with id {request.Id} does not exists");
            }
                
            entity.JobTitle = request.JobTitle;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            if (!string.IsNullOrEmpty(request.Password))
            {
                entity.Password = _passwordEncryptor.Encrypt(request.Password);
                var userContext = await _dbContext.Users.FindAsync(_applicationContext.UserId);

                await _emailSender.SendPasswordHasBeenChangedByAdministrator(entity.Email, userContext.Email);
            }

            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
