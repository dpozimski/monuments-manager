using MediatR;
using Monuments.Manager.Application.Monuments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetMonumentsStatsQuery : IRequest<GetMonumentsStatsQueryResult>
    {

    }
}
