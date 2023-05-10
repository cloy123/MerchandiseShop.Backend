using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.OrderItems.Commands.DeleteOrderItemFromOrder
{
    public class CancelOrderCommand : IRequest<CancelOrderResultVm>
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
    }
}
