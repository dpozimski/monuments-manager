using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Monuments.Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionariesController : BaseController
    {
        public DictionariesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
