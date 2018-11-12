using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure
{
    public static class EnumExtensions
    {
        public static TEnum ConvertTo<TEnum>(this Enum @enum) where TEnum : Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), @enum.ToString());
        }
    }
}
