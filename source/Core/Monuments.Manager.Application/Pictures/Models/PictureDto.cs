using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Pictures.Models
{
    public class PictureDto
    {
        public int Id { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Original { get; set; }
        public string Description { get; set; }
    }
}
