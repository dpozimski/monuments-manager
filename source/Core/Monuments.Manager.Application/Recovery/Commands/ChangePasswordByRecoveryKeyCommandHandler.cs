using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Application.Recovery.Models;
using Monuments.Manager.Persistence;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Recovery.Commands
{
    public class ChangePasswordByRecoveryKeyCommandHandler : IRequestHandler<ChangePasswordByRecoveryKeyCommand>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IStringEncoder _stringEncoder;
        private readonly IPasswordEncryptor _passwordEncryptor;

        public ChangePasswordByRecoveryKeyCommandHandler(MonumentsDbContext dbContext,
                                                         IStringEncoder stringEncoder,
                                                         IPasswordEncryptor passwordEncryptor)
        {
            _dbContext = dbContext;
            _stringEncoder = stringEncoder;
            _passwordEncryptor = passwordEncryptor;
        }

        public async Task<Unit> Handle(ChangePasswordByRecoveryKeyCommand request, CancellationToken cancellationToken)
        {
            var decryptedRecoveryKey = _stringEncoder.Decrypt(request.RecoveryKey);
            var encrytedUserDto = JsonConvert.DeserializeObject<EncryptedUserDto>(decryptedRecoveryKey);

            var userEntity = await _dbContext.Users.FindAsync(encrytedUserDto.Id);
            if (userEntity is null || userEntity.Password != encrytedUserDto.Password)
            {
                throw new RecoveryKeyValidationException(encrytedUserDto.Id);
            }

            userEntity.Password = _passwordEncryptor.Encrypt(request.Password);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
