using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class AuthenticationException : MonumentsManagerAppException
    {
        public AuthenticationException(string id) :
            base($"User with id {id} is not authenticated to execute current operation")
        {

        }
    }
}
