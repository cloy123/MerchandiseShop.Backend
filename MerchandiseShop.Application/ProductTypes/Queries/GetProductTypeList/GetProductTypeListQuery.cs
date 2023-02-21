using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeList
{
    public class GetProductTypeListQuery : IRequest<ProductTypeListVm>
    {
    }
}
