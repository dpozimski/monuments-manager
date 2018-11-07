using System.Collections;

namespace Monuments.Manager.Domain.Entities
{
    public class StreetEntity : BaseEntity
    {
        public int CityId { get; set; }
        public CityEntity City { get; set; }

        public string Name { get; set; }
    }
}