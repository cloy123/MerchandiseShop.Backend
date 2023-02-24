using MediatR;
using MerchandiseShop.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResultVm>
    {
        public Guid UserId { get; set; }

        public IList<CreateOrderItemDto> OrderItems { get; set; }
    }
}
