using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monuments.Manager.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator Mediator { get; }

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
