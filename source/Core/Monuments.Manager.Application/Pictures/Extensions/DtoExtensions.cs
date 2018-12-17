using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Domain.Entities;

namespace Monuments.Manager.Application.Pictures.Extensions
{
    public static class DtoExtensions
    {
        public static PictureDto ToDto(this PictureEntity pictureEntity, bool onlySmallImage = false)
        {
            if(pictureEntity is null)
            {
                return null;
            }

            return new PictureDto()
            {
                Small = pictureEntity.Small,
                Description = pictureEntity.Description,
                Id = pictureEntity.Id,
                Medium = onlySmallImage ? pictureEntity.Medium : null,
                Original = onlySmallImage ? pictureEntity.Original : null
            };
        }
    }
}
