using Microsoft.Extensions.Options;
using Monuments.Manager.Application.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure.Encryption
{
    public class PKCS7StringEncoder : IStringEncoder
    {
        private const string InitVector = "h7g3e4m3t5st5zjw";
        private const int KeySize = 256;

        private readonly ApplicationSecurityOptions _appSecurityOptions;

        public PKCS7StringEncoder(IOptions<ApplicationSecurityOptions> appSecurityOptions)
        {
            _appSecurityOptions = appSecurityOptions.Value;
        }

        public string Encrypt(string plainText)
        {
            var initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var password = new PasswordDeriveBytes(_appSecurityOptions.PasswordSalt, null);
            var keyBytes = password.GetBytes(KeySize / 8);
            var symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Decrypt(string cipherText)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            var password = new PasswordDeriveBytes(_appSecurityOptions.PasswordSalt, null);
            var keyBytes = password.GetBytes(KeySize / 8);
            var symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
