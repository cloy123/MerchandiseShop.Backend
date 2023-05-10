using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.OrderItems.Commands.DeleteOrderItemFromOrder
{
    public class CancelOrderResultVm
    {
        public bool IsCanceled { get; set; }
        public string ErrorMessage { get; set; }
    }
}
