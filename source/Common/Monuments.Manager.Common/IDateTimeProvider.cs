using System;

namespace Monuments.Manager.Common
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrent();
    }
}