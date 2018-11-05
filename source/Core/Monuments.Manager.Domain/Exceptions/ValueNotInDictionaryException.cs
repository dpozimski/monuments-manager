using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Domain.Exceptions
{
    public class ValueNotInDictionaryException : Exception
    {
        public ValueNotInDictionaryException(string propertyName, string value)
            : base($"Value \"{value}\" is not in dictionary and cannot be stored in {propertyName} property")
        {

        }
    }
}
