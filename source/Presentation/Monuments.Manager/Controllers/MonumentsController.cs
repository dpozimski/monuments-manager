using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Monuments.Commands;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Application.Monuments.Queries;
using Monuments.Manager.ViewModels;

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
        public async Task<MonumentPreviewDto> CreateAsync(CreateMonumentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("stats")]
        public async Task<GetMonumentsStatsQueryResult> GetMonumentsStatsAsync()
        {
            return await Mediator.Send(new GetMonumentsStatsQuery());
        }

        [HttpGet]
        public async Task<MonumentDto> GetAsync([FromQuery]GetMonumentQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("monuments/recent/details")]
        public async Task<MonumentDto> GetRecentDetailsAsync([FromQuery]GetRecentMonumentDetailsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("monuments/recent")]
        public async Task<ICollection<MonumentPreviewDto>> GetRecentAsync([FromQuery]GetRecentMonumentsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("monuments")]
        public async Task<ICollection<MonumentPreviewDto>> GetAsync([FromQuery]GetMonumentsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<MonumentPreviewDto> UpdateAsync(UpdateMonumentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteAsync([FromQuery]DeleteMonumentCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
