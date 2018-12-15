using MediatR;
using Monuments.Manager.Application.Monuments.Models;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetMonumentQuery : IRequest<MonumentDto>
    {
        public int MonumentId { get; set; }
    }
}
