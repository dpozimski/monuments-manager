using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure.Encryption
{
    public interface IPasswordEncryptor
    {
        string Encrypt(string password);
    }
}
