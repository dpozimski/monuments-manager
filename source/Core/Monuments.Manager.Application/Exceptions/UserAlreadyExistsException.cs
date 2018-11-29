using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class UserAlreadyExistsException : MonumentsManagerAppException
    {
        public UserAlreadyExistsException(string email)
            : base($"User with email {email} already exists")
        {

        }
    }
}
