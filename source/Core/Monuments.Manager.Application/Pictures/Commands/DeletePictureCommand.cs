using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Pictures.Commands
{
    public class DeletePictureCommand : IRequest
    {
        public int PictureId { get; set; }
    }
}
