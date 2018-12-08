using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure
{
    public static class ApplicationAttributesExtensions
    {
        public static bool HasAttribute<T>(this object obj) where T : Attribute
        {
            return obj.GetType()
                .GetCustomAttributes(typeof(T), true)
                .Any();
        }
    }
}
