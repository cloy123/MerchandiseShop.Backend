using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public Guid ProductTypeId { get; set; }
        public Guid ProductSizeId { get; set; }
        public Guid ProductColorId { get; set; }
        public bool ShowInCatalog { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string ImageFileName { get; set; }
    }
}
