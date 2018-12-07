using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Application.Users.Queries;
using Monuments.Manager.Infrastructure.Security;
using Monuments.Manager.ViewModels;
using System.Collections.Generic;
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

        [AllowAnonymous]
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

        [HttpGet("all")]
        public async Task<ICollection<UserDto>> GetAllAsync(GetUsersQuery query)
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
        public async Task<AuthenticateUserResultViewModel> AuthenticateAsync(AuthenticateUserViewModel viewModel)
        {
            var result = await _authenticationService.AuthenticateAsync(viewModel.Email, viewModel.Password);

            return new AuthenticateUserResultViewModel()
            {
                User = result.User,
                Token = result.Token
            };
        }

        [HttpDelete]
        public async Task DeleteAsync(DeleteUserCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
