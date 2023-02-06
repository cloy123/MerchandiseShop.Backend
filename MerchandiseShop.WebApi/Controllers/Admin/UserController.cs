using AutoMapper;
using MerchandiseShop.Application.Users.Commands.CreateUser;
using MerchandiseShop.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("identity/{version:apiVersion}/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        ///// <summary>
        ///// Получить праздник по id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("{id}")]
        ////[Authorize]
        //public async Task<ActionResult<HolidayDetailsVm>> Get(Guid id)
        //{
        //    var query = new GetHolidayDetailsQuery
        //    {
        //        Id = id
        //    };
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}


        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="createHolidayDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createHolidayDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createHolidayDto);
            var holidayId = await Mediator.Send(command);
            return Ok(holidayId);
        }
    }
}
