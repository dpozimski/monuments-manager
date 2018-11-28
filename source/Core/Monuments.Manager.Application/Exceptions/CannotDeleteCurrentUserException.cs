using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class CannotDeleteCurrentUserException : Exception
    {
        public CannotDeleteCurrentUserException(int userId, string email)
            : base($"Cannot delete user {userId} {email} because it is used in the current session")
        {
        }
    }
}
