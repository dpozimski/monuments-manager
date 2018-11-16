using MediatR;
using Monuments.Manager.Application.Dictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Queries
{
    public class GetCommunesQuery : IRequest<ICollection<DictionaryValueDto>>
    {
        public string Province { get; set; }
        public string District { get; set; }
    }
}
