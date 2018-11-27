using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class ChangePasswordByRecoveryKeyCommandHandler : IRequestHandler<ChangePasswordByRecoveryKeyCommand>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IStringEncoder _stringEncoder;

        public ChangePasswordByRecoveryKeyCommandHandler(MonumentsDbContext dbContext,
                                                         IStringEncoder stringEncoder)
        {
            _dbContext = dbContext;
            _stringEncoder = stringEncoder;
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

            userEntity.Password = request.Password;
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
