using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Application.Users.Queries;
using Monuments.Manager.Infrastructure;
using Monuments.Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monuments.Manager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public UsersController(IMediator mediator,
                               IAuthenticationService authenticationService) : base(mediator)
        {
            _authenticationService = authenticationService;
        }

        [HttpPut]
        public async Task<int> CreateAsync(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<UserDto> GetAsync([FromQuery]GetUserByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task UpdateAsync(UpdateUserCommand command)
        {
            await Mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("authentication")]
        public async Task<string> AuthenticateAsync(AuthenticateUserViewModel viewModel)
        {
            return await _authenticationService.AuthenticateAsync(viewModel);
        }

        [HttpDelete]
        public async Task DeleteAsync(DeleteUserCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
