using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Infrastructure.Models
{
    public class ApplicationSecurity
    {
        public string JwtSecretKey { get; set; }
        public string PasswordSalt { get; set; }
    }
}
