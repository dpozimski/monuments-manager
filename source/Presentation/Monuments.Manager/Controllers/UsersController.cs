using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monuments.Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut]
        public async Task<int> CreateAsync(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<UserDto> GetAsync([FromQuery]GetUserQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task UpdateAsync(UpdateUserCommand command)
        {
            await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteAsync(DeleteUserCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
