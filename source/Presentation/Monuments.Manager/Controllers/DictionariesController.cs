using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monuments.Manager.Application.Dictionary.Models;
using Monuments.Manager.Application.Dictionary.Queries;

namespace Monuments.Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionariesController : BaseController
    {
        public DictionariesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("provinces")]
        public async Task<ICollection<DictionaryValueDto>> GetProvincesAsync()
        {
            return await Mediator.Send(new GetProvincesQuery());
        }

        [HttpGet("{province}")]
        public async Task<ICollection<DictionaryValueDto>> GetDistrictsAsync(string province)
        {
            return await Mediator.Send(new GetDistrictsQuery()
            {
                Province = province
            });
        }

        [HttpGet("{province}/{district}")]
        public async Task<ICollection<DictionaryValueDto>> GetCommunesAsync(string province, string district)
        {
            return await Mediator.Send(new GetCommunesQuery()
            {
                Province = province,
                District = district
            });
        }

        [HttpGet("{province}/{district}/{commune}")]
        public async Task<ICollection<DictionaryValueDto>> GetCitiesAsync(string province, string district, string commune)
        {
            return await Mediator.Send(new GetCitiesQuery()
            {
                Province = province,
                District = district,
                Commune = commune
            });
        }

        [HttpGet("{province}/{district}/{commune}/{city}")]
        public async Task<ICollection<DictionaryValueDto>> GetStreetsAsync(string province, string district, string commune, string city)
        {
            return await Mediator.Send(new GetStreetsQuery()
            {
                Province = province,
                District = district,
                Commune = commune,
                City = city
            });
        }
    }
}
