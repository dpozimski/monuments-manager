using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure
{
    public static class EnumExtensions
    {
        public static TEnum ConvertTo<TEnum>(this object @enum)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), @enum.ToString());
        }
    }
}
