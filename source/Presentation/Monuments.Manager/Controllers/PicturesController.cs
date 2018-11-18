using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Pictures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monuments.Manager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PicturesController : BaseController
    {
        public PicturesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut]
        public async Task<int> CreateAsync(CreatePictureCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeletePictureAsync(DeletePictureCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
