using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Domain.Entities
{
    public class PictureEntity : BaseEntity
    {
        public int MonumentId { get; set; }
        public virtual MonumentEntity Monument { get; set; }

        public string Small { get; set; }
        public string Medium { get; set; }
        public string Original { get; set; }

        public string Description { get; set; }
    }
}
