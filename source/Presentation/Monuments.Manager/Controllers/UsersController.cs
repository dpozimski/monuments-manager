using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<UserDto> GetAsync(GetUserQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task UpdateAsync(UpdateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteAsync(DeleteUserCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
