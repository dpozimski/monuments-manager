using System;
using System.Collections.Generic;
using System.Text;
using Monuments.Manager.Domain.Enumerations;

namespace Monuments.Manager.Domain.Entities
{
    public class ProvinceEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<DistrictEntity> Districts { get; private set; }

        public ProvinceEntity()
        {
            Districts = new HashSet<DistrictEntity>();
        }
    }
}
