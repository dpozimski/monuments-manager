using Monuments.Manager.Application.Pictures.Models;
using System;
using System.Collections.Generic;

namespace Monuments.Manager.Application.Monuments.Models
{
    public class MonumentDto
    {
        public int Id { get; set; }
        
        public string OwnerName { get; set; }

        public string Name { get; set; }
        public DateTime ConstructionDate { get; set; }
        public AddressDto Address { get; set; }
        public string FormOfProtection { get; set; }

        public ICollection<PictureDto> Pictures { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
