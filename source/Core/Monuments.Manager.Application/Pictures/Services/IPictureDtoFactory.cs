using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Domain.Entities;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Infrastructure
{
    public interface IPictureDtoFactory
    {
        PictureDto Convert(PictureEntity pictureEntity, bool generateMultiSizeVersions);
    }
}
