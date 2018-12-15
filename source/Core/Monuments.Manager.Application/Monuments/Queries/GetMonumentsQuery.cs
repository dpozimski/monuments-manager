using MediatR;
using Monuments.Manager.Application.Monuments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetMonumentsQuery : IRequest<ICollection<MonumentPreviewDto>>
    {
        public bool DescSortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Filter { get; set; }
    }
}
