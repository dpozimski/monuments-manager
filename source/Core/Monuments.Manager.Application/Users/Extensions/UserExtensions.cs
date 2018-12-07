using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Extensions
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this UserEntity user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                JobTitle = user.JobTitle,
                Role = user.Role.ConvertTo<UserRoleDto>()
            };
        }
    }
}
