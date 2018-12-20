using MediatR;
using Monuments.Manager.Application.Monuments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Monuments.Commands
{
    public class UpdateMonumentCommand : IRequest<MonumentPreviewDto>
    {
        public int MonumentId { get; set; }
        public string Name { get; set; }
        public string FormOfProtection { get; set; }
        public DateTime ConstructionDate { get; set; }
        public AddressDto Address { get; set; }
    }
}
