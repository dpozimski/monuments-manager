using System.Collections.Generic;

namespace Monuments.Manager.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        public int CommuneId { get; set; }
        public CommuneEntity Commune { get; set; }

        public string Name { get; set; }
        public ICollection<StreetEntity> Streets { get; private set; }

        public CityEntity()
        {
            Streets = new HashSet<StreetEntity>();
        }
    }
}