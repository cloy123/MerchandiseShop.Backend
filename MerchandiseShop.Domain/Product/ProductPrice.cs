using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Product
{
    public class ProductPrice
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
    }
}
