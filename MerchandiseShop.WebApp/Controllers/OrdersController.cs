using AutoMapper;
using MerchandiseShop.Application.Orders.Commands.UpdateOrderStatus;
using MerchandiseShop.Application.Orders.Queries.GetOrderDetails;
using MerchandiseShop.Application.Orders.Queries.GetOrderList;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetOrderListQuery();
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public async Task<IActionResult> Details(Guid orderId)
        {
            var query = new GetOrderDetailsQuery
            {
                Id = orderId
            };
            var order = await Mediator.Send(query);
            var orderDto = _mapper.Map<OrderDto>(order);
            return View("Details", orderDto);
        }

        public async Task<IActionResult> UpdateStatus(Guid orderId, int statusId)
        {
            var command = new UpdateOrderStatusCommand
            {
                Id = orderId,
                StatusId = statusId
            };
            var orderDetailsVm = await Mediator.Send(command);
            var orderDto = _mapper.Map<OrderDto>(orderDetailsVm);
            return View("Details", orderDto);
        }
    }
}
