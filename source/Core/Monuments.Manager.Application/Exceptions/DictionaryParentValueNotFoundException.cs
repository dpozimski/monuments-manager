using MediatR;
using Monuments.Manager.Application.Dictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Exceptions
{
    public class DictionaryParentValueNotFoundException : Exception
    {
        public DictionaryParentValueNotFoundException(IRequest<ICollection<DictionaryValueDto>> query)
            : base($"Parent value for {query.GetType().Name} not exists. Details: {query}")
        {

        }
    }
}
