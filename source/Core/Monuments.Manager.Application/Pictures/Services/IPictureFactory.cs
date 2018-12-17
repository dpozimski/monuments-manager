using Monuments.Manager.Application.Pictures.Commands;
using Monuments.Manager.Domain.Entities;

namespace Monuments.Manager.Application.Infrastructure
{
    public interface IPictureFactory
    {
        PictureEntity Create(CreatePictureCommand command);
    }
}
