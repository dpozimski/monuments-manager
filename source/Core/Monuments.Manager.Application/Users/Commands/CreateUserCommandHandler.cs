using MediatR;
using Monuments.Manager.Application.Email;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Domain.Enumerations;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
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
            await _emailSender.SendWelcomeMailAsync(request.Email);

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
