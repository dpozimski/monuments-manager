using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Models
{
    public class GetMonumentdQueryResult
    {
        public ICollection<MonumentPreviewDto> Monuments { get; set; }
        public int LeftCount { get; set; }
    }
}
