using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Queries.GetOrderList
{
    public class OrderListVm
    {
        public IList<OrderDetailsVm> Orders { get; set; }
    }
}
