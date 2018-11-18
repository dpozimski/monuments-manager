using Monuments.Manager.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Infrastructure
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}
