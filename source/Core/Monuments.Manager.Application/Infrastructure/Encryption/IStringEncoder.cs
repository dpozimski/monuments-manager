using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure.Encryption
{
    public interface IStringEncoder
    {
        string Encrypt(string content);
        string Decrypt(string encrypted);
    }
}
