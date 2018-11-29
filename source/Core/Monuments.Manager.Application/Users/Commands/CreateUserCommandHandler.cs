using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Email;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPasswordEncryptor _passwordEncryptor;
        private readonly IEmailSender _emailSender;

        public CreateUserCommandHandler(MonumentsDbContext dbContext,
                                        IPasswordEncryptor passwordEncryptor,
                                        IEmailSender emailSender)
        {
            _dbContext = dbContext;
            _passwordEncryptor = passwordEncryptor;
            _emailSender = emailSender;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(await _dbContext.Users.AnyAsync(s => s.Email == request.Email))
            {
                throw new MonumentsManagerAppException(ExceptionType.UserAlreadyExists, $"User with email {request.Email} already exists");
            }

            if (!await _emailSender.TrySendWelcomeMailAsync(request.Email))
            {
                throw new MonumentsManagerAppException(ExceptionType.CannotSendEmail, $"Cannot send welcome mail to {request.Email}");
            }

            var entity = new UserEntity()
            {
                Password = _passwordEncryptor.Encrypt(request.Password),
                Email = request.Email,
                JobTitle = request.JobTitle
            };

            var result = await _dbContext.AddAsync(entity, cancellationToken);

            return result.Entity.Id;
        }
    }
}
