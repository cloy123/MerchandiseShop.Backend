using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Queries.GetProductSizeList
{
    public class ProductSizeListVm
    {
        public IList<ProductSizeDetailsVm> ProductSizes { get; set; }
    }
}
