using MediatR;
using Monuments.Manager.Application.Monuments.Models;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetRecentMonumentDetailsQuery : IRequest<MonumentDto>
    {
        public int MonumentId { get; set; }
    }
}
