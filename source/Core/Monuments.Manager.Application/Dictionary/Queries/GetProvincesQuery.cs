using MediatR;
using Monuments.Manager.Application.Dictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Queries
{
    public class GetProvincesQuery : IRequest<ICollection<DictionaryValueDto>>
    {
    }
}
