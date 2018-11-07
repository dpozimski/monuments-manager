using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence
{
    public interface IConfigurationBuilder
    {
        void ApplyConfiguration(ModelBuilder builder);
    }
}
