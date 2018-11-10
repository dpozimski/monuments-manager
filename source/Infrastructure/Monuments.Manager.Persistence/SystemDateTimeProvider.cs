using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}
