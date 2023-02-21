using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Queries.GetProductColorDetails
{
    public class GetProductColorDetailsQuery : IRequest<ProductColorDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
