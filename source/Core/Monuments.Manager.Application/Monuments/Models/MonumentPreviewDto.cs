using Monuments.Manager.Application.Pictures.Models;
using System;

namespace Monuments.Manager.Application.Monuments.Models
{
    public class MonumentPreviewDto
    {
        public int Id { get; set; }
        
        public string OwnerName { get; set; }

        public string Name { get; set; }
        public DateTime ConstructionDate { get; set; }
        public AddressDto Address { get; set; }

        public PictureDto Picture { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
