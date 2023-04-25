using AutoMapper;
using MerchandiseShop.Application.Orders.Commands.CreateOrder;
using MerchandiseShop.Application.Orders.Queries.GetOrderList;
using MerchandiseShop.Application.Users.Queries.GetUserDetails;
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<OrdersInfoVm>> GetOrdersInfo()
        {

            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var queryUser = new GetUserDetailsQuery() { Id = Guid.Parse(userIdClaim.Value) };
            var user = await Mediator.Send(queryUser);
            if (user == null)
            {
                return Unauthorized();
            }


            var queryOrders = new GetOrderListQuery();
            var orders = (await Mediator.Send(queryOrders)).Orders.Where(o => o.UserId == user.Id).ToList();

            var result = new List<OrderDto>();

            foreach (var order in orders)
            {
                var orderDto = _mapper.Map<OrderDto>(order);
                orderDto.OrderItems = _mapper.Map<List<OrderItemDto>>(order.OrderItems);
                result.Add(orderDto);
            }

            return Ok(new OrdersInfoVm
            {
                Orders = result
            }) ;
        }
    }
}
