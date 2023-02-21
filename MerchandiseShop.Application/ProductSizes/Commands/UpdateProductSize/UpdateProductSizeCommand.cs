using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Commands.UpdateProductSize
{
    public class UpdateProductSizeCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
