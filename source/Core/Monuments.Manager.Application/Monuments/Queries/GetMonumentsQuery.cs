using MediatR;
using Monuments.Manager.Application.Monuments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetMonumentsQuery : IRequest<GetMonumentdQueryResult>
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}
