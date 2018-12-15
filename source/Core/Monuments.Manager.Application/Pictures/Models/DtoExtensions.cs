using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Pictures.Models
{
    public static class DtoExtensions
    {
        public static PictureDto ToDto(this PictureEntity pictureEntity, IImageFactory imageFactory, bool thumbnail)
        {
            return new PictureDto()
            {
                Id = pictureEntity.Id,
                Data = thumbnail ? imageFactory.CreateThumbnail(pictureEntity.Data) : imageFactory.Encode(pictureEntity.Data),
                Description = pictureEntity.Description,
            };
        }
    }
}
