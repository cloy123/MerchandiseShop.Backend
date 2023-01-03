using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Product
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public Guid SizeId { get; set; }
        public Guid ColorId { get; set; }
        public bool ShowInCatalog { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
    }
}
