using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Commands
{
    public class DeleteMonumentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
