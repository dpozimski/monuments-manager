using Monuments.Manager.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure.Models
{
    public class ApplicationContext : IApplicationContext
    {
        public int UserId { get; set; }
    }
}
