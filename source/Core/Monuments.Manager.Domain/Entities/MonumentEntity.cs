using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Domain.Entities
{
    public class MonumentEntity : BaseEntity
    {
        public int UserId { get; set; }

        public string Name { get; set; }
        public string FormOfProtection { get; set; }
        public DateTime ConstructionDate { get; set; }
        public AddressEntity Address { get; set; }
        public ICollection<PictureEntity> Pictures { get; private set; }

        public MonumentEntity()
        {
            Pictures = new HashSet<PictureEntity>();
        }
    }
}
