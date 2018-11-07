using System;
using System.Collections.Generic;
using System.Text;
using Monuments.Manager.Domain.Enumerations;

namespace Monuments.Manager.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserRole Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }

        public ICollection<MonumentEntity> Monuments { get; private set; }

        public UserEntity()
        {
            Monuments = new HashSet<MonumentEntity>();
        }
    }
}
