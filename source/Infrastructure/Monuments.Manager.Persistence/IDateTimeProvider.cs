using System;

namespace Monuments.Manager.Persistence
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrent();
    }
}