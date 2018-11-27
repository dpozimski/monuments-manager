using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Email;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Application.Recovery.Models;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Recovery.Commands
{
    public class SendRecoveryKeyCommandHandler : IRequestHandler<SendRecoveryKeyCommand>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IEmailSender _emailSender;
        private readonly IStringEncoder _stringEncoder;

        public SendRecoveryKeyCommandHandler(MonumentsDbContext dbContext,
                                             IEmailSender emailSender,
                                             IStringEncoder stringEncoder)
        {
            _dbContext = dbContext;
            _emailSender = emailSender;
            _stringEncoder = stringEncoder;
        }

        public async Task<Unit> Handle(SendRecoveryKeyCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _dbContext.Users.FirstOrDefaultAsync(s => s.Username == request.Username);

            if(userEntity is null)
            {
                throw new EntityNotFoundException<UserEntity>(userEntity.Username);
            }

            var recoveryKey = GenerateRecoveryKey(userEntity);

            await _emailSender.SendRecoveryPasswordMailAsync(userEntity.Username, recoveryKey);

            return Unit.Value;
        }

        private string GenerateRecoveryKey(UserEntity userEntity)
        {
            var encryptedUser = new EncryptedUserDto()
            {
                Id = userEntity.Id,
                Password = userEntity.Password
            };

            var jsonValue = JsonConvert.SerializeObject(encryptedUser);

            return _stringEncoder.Encrypt(jsonValue);
        }
    }
}
