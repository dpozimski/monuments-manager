using MediatR;
using Monuments.Manager.Application.Pictures.Models;

namespace Monuments.Manager.Application.Pictures.Query
{
    public class GetPictureByIdQuery : IRequest<PictureDto>
    {
        public int Id { get; set; }
    }
}
