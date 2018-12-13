using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure
{
    public interface IImageFactory
    {
        string CreateThumbnail(byte[] image);
        string Encode(byte[] image);
        byte[] Decode(string image);
    }
}
