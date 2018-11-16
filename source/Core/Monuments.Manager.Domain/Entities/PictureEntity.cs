using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Domain.Entities
{
    public class PictureEntity : BaseEntity
    {
        public int MonumentId { get; set; }
        public virtual MonumentEntity Monument { get; set; }

        public byte[] Data { get; set; }
    }
}
