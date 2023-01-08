using AutoMapper;
using MerchandiseShop.Application.Holidays.Commands.CreateHoliday;
using MerchandiseShop.Application.Holidays.Queries.GetHolidayDetails;
using MerchandiseShop.Application.Holidays.Queries.GetHolidaysList;
using MerchandiseShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MerchandiseShop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HolidayController : BaseController
    {
        private readonly IMapper _mapper;

        public HolidayController(IMapper mapper)
        {
            _mapper = mapper;
        }


        /// <summary>
        /// Получить список праздников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<HolidayListVm>> GetAll()
        {
            var query = new GetHolidayListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Получить праздник по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<HolidayDetailsVm>> Get(Guid id)
        {
            var query = new GetHolidayDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Создать праздник
        /// </summary>
        /// <param name="createHolidayDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHolidayDto createHolidayDto)
        {
            var command = _mapper.Map<CreateHolidayCommand>(createHolidayDto);
            var holidayId = await Mediator.Send(command);
            return Ok(holidayId);
        }
    }
}
