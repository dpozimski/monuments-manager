using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Monuments.Manager.Application.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure.Encryption
{
    public class Pbkdf2PasswordEncryptor : IPasswordEncryptor
    {
        private const int IterationCount = 10000;
        private const int NumBytes = 32;

        private readonly IOptions<ApplicationSecurityOptions> _applicationSecurityOptions;

        public Pbkdf2PasswordEncryptor(IOptions<ApplicationSecurityOptions> applicationSecurityOptions)
        {
            _applicationSecurityOptions = applicationSecurityOptions;
        }

        public string Encrypt(string password)
        {
            var salt = Encoding.UTF8.GetBytes(_applicationSecurityOptions.Value.PasswordSalt);

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: IterationCount,
                numBytesRequested: NumBytes));

            return hashed;
        }
    }
}
