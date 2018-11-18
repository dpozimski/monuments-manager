using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Pictures.Commands
{
    public class CreatePictureCommand : IRequest<int>
    {
        public int MonumentId { get; set; }
        public byte[] Data { get; set; }
    }
}
