using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure
{
    public interface IThumbnailImageFactory
    {
        byte[] Create(byte[] image);
    }
}
