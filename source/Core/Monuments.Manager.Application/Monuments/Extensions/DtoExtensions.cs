using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Monuments.Manager.Application.Monuments.Extensions
{
    public static class DtoExtensions
    {
        public static AddressDto ToDto(this AddressEntity addressEntity)
        {
            return new AddressDto()
            {
                Area = addressEntity.Area,
                City = addressEntity.City,
                Commune = addressEntity.Commune,
                District = addressEntity.District,
                Province = addressEntity.Province,
                Street = addressEntity.Street,
                StreetNumber = addressEntity.StreetNumber
            };
        }

        public static MonumentPreviewDto ToPreviewDto(this MonumentEntity monumentEntity, PictureDto pictureDto)
        {
            return new MonumentPreviewDto()
            {
                Id = monumentEntity.Id,
                ConstructionDate = monumentEntity.ConstructionDate,
                Name = monumentEntity.Name,
                OwnerId = monumentEntity.UserId,
                OwnerName = monumentEntity.User.Email,
                Picture = pictureDto,
                Address = monumentEntity.Address.ToDto()
            };
        }

        public static MonumentDto ToDto(this MonumentEntity monumentEntity, ICollection<PictureDto> pictureDtos)
        {
            return new MonumentDto()
            {
                Id = monumentEntity.Id,
                ConstructionDate = monumentEntity.ConstructionDate,
                Name = monumentEntity.Name,
                OwnerId = monumentEntity.UserId,
                OwnerName = monumentEntity.User.Email,
                Pictures = pictureDtos,
                Address = monumentEntity.Address.ToDto()
            };
        }
    }
}
