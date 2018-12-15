using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Pictures.Extensions
{
    public static class ImageExtensions
    {
        public static byte[] Decode(this string base64)
        {
            return Convert.FromBase64String(base64);
        }

        public static string Encode(this byte[] image)
        {
            return Convert.ToBase64String(image);
        }
    }
}
