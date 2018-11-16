using MediatR;
using Monuments.Manager.Application.Dictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Queries
{
    public class GetStreetsQuery : IRequest<ICollection<DictionaryValueDto>>
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Commune { get; set; }
        public string City { get; set; }
    }
}
