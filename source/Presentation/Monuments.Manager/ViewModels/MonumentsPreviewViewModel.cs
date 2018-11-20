using Monuments.Manager.Application.Monuments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monuments.Manager.ViewModels
{
    public class MonumentsPreviewViewModel
    {
        public ICollection<MonumentPreviewDto> Monuments { get; set; }
        public int PagesCount { get; set; }
    }
}
