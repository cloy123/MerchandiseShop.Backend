using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.OrderItems.Queries.GetOrderItemList
{
    public class OrderItemListVm
    {
        public IList<OrderItemDetailsVm> OrderItems { get; set; }
    }
}
