using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Application.Pictures.Extensions;
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

        public static MonumentPreviewDto ToPreviewDto(this MonumentEntity monumentEntity, PictureEntity pictureEntity)
        {
            return new MonumentPreviewDto()
            {
                Id = monumentEntity.Id,
                ConstructionDate = monumentEntity.ConstructionDate,
                Name = monumentEntity.Name,
                OwnerName = monumentEntity.User.Email,
                Picture = pictureEntity.ToDto(true),
                Address = monumentEntity.Address.ToDto(),
                ModifiedDate = monumentEntity.ModifiedDate,
                ModifiedBy = monumentEntity.ModifiedBy
            };
        }

        public static MonumentDto ToDto(this MonumentEntity monumentEntity, ICollection<PictureEntity> pictureEntities)
        {
            return new MonumentDto()
            {
                Id = monumentEntity.Id,
                ConstructionDate = monumentEntity.ConstructionDate,
                Name = monumentEntity.Name,
                OwnerName = monumentEntity.User.Email,
                Pictures = pictureEntities.Select(s => s.ToDto()).ToList(),
                Address = monumentEntity.Address.ToDto(),
                ModifiedBy = monumentEntity.User.ModifiedBy,
                ModifiedDate = monumentEntity.User.ModifiedDate,
                FormOfProtection = monumentEntity.FormOfProtection
            };
        }
    }
}
