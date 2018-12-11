using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
