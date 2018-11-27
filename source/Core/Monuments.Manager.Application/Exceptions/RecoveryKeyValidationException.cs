using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class RecoveryKeyValidationException : Exception
    {
        public RecoveryKeyValidationException(int userId)
            : base($"Recovery key is invalid for user with id {userId}")
        {
        }
    }
}
