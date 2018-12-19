using MediatR;
using Monuments.Manager.Application.Monuments.Models;
using System;

namespace Monuments.Manager.Application.Monuments.Commands
{
    public class CreateMonumentCommand : IRequest<MonumentPreviewDto>
    {
        public string Name { get; set; }
        public string FormOfProtection { get; set; }
        public DateTime ConstructionDate { get; set; }
        public AddressDto Address { get; set; }
    }
}
