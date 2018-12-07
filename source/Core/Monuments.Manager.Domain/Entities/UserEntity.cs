using System;
using System.Collections.Generic;
using System.Text;
using Monuments.Manager.Domain.Enumerations;

namespace Monuments.Manager.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public DateTime LastLoggedIn { get; set; }

        public virtual ICollection<MonumentEntity> Monuments { get; private set; }

        public UserEntity()
        {
            Monuments = new HashSet<MonumentEntity>();
        }
    }
}
