using MediatR;
using MerchandiseShop.Application.Orders.Queries.GetOrderList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.OrderItems.Queries.GetOrderItemList
{
    public class GetOrderItemListQuery : IRequest<OrderItemListVm>
    {
        public Guid OrderId { get; set; }
    }
}
