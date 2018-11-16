using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Domain.Entities
{
    public class DistrictEntity : BaseEntity
    {
        public int ProvinceId { get; set; }
        public virtual ProvinceEntity Province { get; set; }

        public string Name { get; set; }
        public virtual ICollection<CommuneEntity> Communes { get; private set; }

        public DistrictEntity()
        {
            Communes = new HashSet<CommuneEntity>();
        }
    }
}
