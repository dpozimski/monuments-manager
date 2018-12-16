using MediatR;
using Monuments.Manager.Application.Pictures.Models;

namespace Monuments.Manager.Application.Pictures.Commands
{
    public class CreatePictureCommand : IRequest<PictureDto>
    {
        public int MonumentId { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }
    }
}
