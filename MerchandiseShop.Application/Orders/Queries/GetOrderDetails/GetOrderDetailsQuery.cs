using MediatR;
using MerchandiseShop.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
