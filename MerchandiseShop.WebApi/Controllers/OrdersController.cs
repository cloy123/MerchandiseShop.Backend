using AutoMapper;
using MerchandiseShop.Application.Orders.Commands.CreateOrder;
using MerchandiseShop.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateOrderResultVm>> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
            if(userIdClaim != null)
            {
                command.UserId = Guid.Parse(userIdClaim.Value);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return Unauthorized();
        }
    }
}
