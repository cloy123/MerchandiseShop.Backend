using AutoMapper;

namespace MerchandiseShop.WebApp.Controllers.Admin
{
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[HttpPost]
        //public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createHolidayDto)
        //{
        //    var command = _mapper.Map<CreateUserCommand>(createHolidayDto);
        //    var holidayId = await Mediator.Send(command);
        //    return Ok(holidayId);
        //}
    }
}
