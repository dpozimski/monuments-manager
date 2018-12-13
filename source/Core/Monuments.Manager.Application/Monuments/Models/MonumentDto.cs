using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Models
{
    public class MonumentDto
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }
        public string OwnerName { get; set; }

        public string Name { get; set; }
        public DateTime ConstructionDate { get; set; }
        public AddressDto Address { get; set; }

        public string Picture { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
