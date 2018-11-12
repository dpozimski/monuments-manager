using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Models
{
    public class AddressDto
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Commune { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Area { get; set; }
    }
}
