using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Monuments.Commands;

namespace Monuments.Manager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MonumentsController : BaseController
    {
        public MonumentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut]
        public async Task<int> CreateAsync(CreateMonumentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task UpdateAsync(UpdateMonumentCommand command)
        {
            await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteAsync([FromQuery]DeleteMonumentCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
