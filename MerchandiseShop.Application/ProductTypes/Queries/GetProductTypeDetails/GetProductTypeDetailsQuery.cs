using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeDetails
{
    public class GetProductTypeDetailsQuery : IRequest<ProductTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
