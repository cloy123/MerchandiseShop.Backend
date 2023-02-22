using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public IList<ProductDetailsVm> Products { get; set; }
    }
}
