using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class MonumentsManagerAppException : Exception
    {
        public ExceptionType Type { get; }

        public MonumentsManagerAppException(ExceptionType type, string message) : base(message)
        {
            Type = type;
        }
    }
}
