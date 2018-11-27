using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Recovery.Commands;

namespace Monuments.Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecoveryController : BaseController
    {
        public RecoveryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("reset-password")]
        public async Task ChangePasswordByRecoveryKeyAsync(ChangePasswordByRecoveryKeyCommand viewModel)
        {
            await Mediator.Send(viewModel);
        }

        [HttpPost("send-recovery-key")]
        public async Task SendRecoveryKeyAsync(SendRecoveryKeyCommand viewModel)
        {
            await Mediator.Send(viewModel);
        }
    }
}
