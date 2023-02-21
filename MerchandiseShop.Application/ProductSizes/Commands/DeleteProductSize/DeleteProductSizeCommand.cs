using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Commands.DeleteProductSize
{
    public class DeleteProductSizeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
