using MediatR;
namespace Monuments.Manager.Application.Pictures.Commands
{
    public class CreatePictureCommand : IRequest<int>
    {
        public int MonumentId { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }
    }
}
