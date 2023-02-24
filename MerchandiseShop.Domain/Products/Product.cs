using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }

        public Guid ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }

        public Guid ProductSizeId { get; set; }

        [ForeignKey("ProductSizeId")]
        public ProductSize ProductSize { get; set; }

        public Guid ProductColorId { get; set; }

        [ForeignKey("ProductColorId")]
        public ProductColor ProductColor { get; set; }

        public bool ShowInCatalog { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public int FreeQuantity { get; set; }
        public int MinQuantity { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public string ImageFileName { get; set; }
    }
}
