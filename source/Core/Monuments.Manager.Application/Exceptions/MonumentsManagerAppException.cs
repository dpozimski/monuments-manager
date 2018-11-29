using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class MonumentsManagerAppException : Exception
    {
        public MonumentsManagerAppException(string message) : base(message)
        {
        }
    }
}
