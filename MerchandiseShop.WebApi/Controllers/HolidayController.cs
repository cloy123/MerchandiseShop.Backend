using AutoMapper;
using MerchandiseShop.Application.Holidays.Commands.CreateHoliday;
using MerchandiseShop.Application.Holidays.Queries.GetHolidayDetails;
using MerchandiseShop.Application.Holidays.Queries.GetHolidaysList;
using MerchandiseShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HolidayController : BaseController
    {
        private readonly IMapper _mapper;

        public HolidayController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<HolidayListVm>> GetAll()
        {
            var query = new GetHolidayListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayDetailsVm>> Get(Guid id)
        {
            var query = new GetHolidayDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHolidayDto createHolidayDto)
        {
            var command = _mapper.Map<CreateHolidayCommand>(createHolidayDto);
            var holidayId = await Mediator.Send(command);
            return Ok(holidayId);
        }
    }
}
