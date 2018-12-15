using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Domain.Entities;
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

        public static MonumentPreviewDto ToPreviewDto(this MonumentEntity monumentEntity, IImageFactory imageFactory)
        {
            return new MonumentPreviewDto()
            {
                Id = monumentEntity.Id,
                ConstructionDate = monumentEntity.ConstructionDate,
                Name = monumentEntity.Name,
                OwnerId = monumentEntity.UserId,
                OwnerName = monumentEntity.User.Email,
                Picture = monumentEntity.Pictures.Count > 0 ? monumentEntity.Pictures.FirstOrDefault().ToDto(imageFactory, true) : null,
                Address = monumentEntity.Address.ToDto()
            };
        }

        public static MonumentDto ToDto(this MonumentEntity monumentEntity, IImageFactory imageFactory)
        {
            return new MonumentDto()
            {
                Id = monumentEntity.Id,
                ConstructionDate = monumentEntity.ConstructionDate,
                Name = monumentEntity.Name,
                OwnerId = monumentEntity.UserId,
                OwnerName = monumentEntity.User.Email,
                Pictures = monumentEntity.Pictures.AsParallel().Select(s => s.ToDto(imageFactory, false)).ToList(),
                Address = monumentEntity.Address.ToDto()
            };
        }
    }
}
