using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Order
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateCompletion { get; set; }
        public int StatusId { get; set; }
    }
}
