﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Models
{
    public class GetMonumentsQueryResult
    {
        public ICollection<MonumentPreviewDto> Monuments { get; set; }
        public int PagesCount { get; set; }
    }
}