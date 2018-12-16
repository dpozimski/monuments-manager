using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Pictures.Commands;
using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Application.Pictures.Query;
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
        public async Task<PictureDto> CreateAsync(CreatePictureCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<PictureDto> GetAsync(GetPictureByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete]
        public async Task DeletePictureAsync(DeletePictureCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
