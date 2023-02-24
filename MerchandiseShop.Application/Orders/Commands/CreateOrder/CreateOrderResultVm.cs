using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderResultVm
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public Guid Id { get; set; }
    }
}
