using System.Collections.Generic;

namespace Monuments.Manager.Domain.Entities
{
    public class CommuneEntity : BaseEntity
    {
        public int DistrictId { get; set; }

        public string Name { get; set; }
        public ICollection<CityEntity> Cities { get; private set; }

        public CommuneEntity()
        {
            Cities = new HashSet<CityEntity>();
        }
    }
}