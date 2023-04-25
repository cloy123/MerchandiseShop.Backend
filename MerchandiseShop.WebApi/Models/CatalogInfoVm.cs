using MerchandiseShop.Application.ProductColors;
using MerchandiseShop.Application.Products;
using MerchandiseShop.Application.ProductSizes;
using MerchandiseShop.Application.ProductTypes;

namespace MerchandiseShop.WebApi.Models
{
    public class CatalogInfoVm
    {
        public List<ProductDetailsVm> Products { get; set; }
        public List<ProductColorDetailsVm> ProductColors { get; set; }
        public List<ProductTypeDetailsVm> ProductTypes { get; set; }
        public List<ProductSizeDetailsVm> ProductSizes { get; set; }
    }
}
