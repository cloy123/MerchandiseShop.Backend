using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Queries.GetProductSizeDetails
{
    public class GetProductSizeDetailsQuery : IRequest<ProductSizeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
