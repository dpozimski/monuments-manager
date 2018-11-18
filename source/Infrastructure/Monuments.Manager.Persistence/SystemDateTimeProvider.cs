﻿using Monuments.Manager.Common;
using System;

namespace Monuments.Manager.Persistence
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrent()
        {
            return DateTime.UtcNow;
        }
    }
}
