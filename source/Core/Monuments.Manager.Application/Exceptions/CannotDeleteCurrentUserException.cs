using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class CannotDeleteCurrentUserException : Exception
    {
        public CannotDeleteCurrentUserException(int userId, string username)
            : base($"Cannot delete user {userId} {username} because it is used in the current session")
        {
        }
    }
}
