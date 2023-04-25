using AutoMapper;
using MerchandiseShop.Application.ProductColors.Queries.GetProductColorList;
using MerchandiseShop.Application.Products.Queries.GetProductList;
using MerchandiseShop.Application.ProductSizes.Queries.GetProductSizeList;
using MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeList;
using MerchandiseShop.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IMapper _mapper;

        public CatalogController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CatalogInfoVm>> GetCatalogInfo()
        {
            var queryProducts = new GetProductListQuery();
            var products = (await Mediator.Send(queryProducts)).Products;
            var queryColors = new GetProductColorListQuery();
            var productColors = (await Mediator.Send(queryColors)).ProductColors;
            var queryTypes = new GetProductTypeListQuery();
            var productTypes = (await Mediator.Send(queryTypes)).ProductTypes;
            var querySizes = new GetProductSizeListQuery();
            var productSizes = (await Mediator.Send(querySizes)).ProductSizes;
            return Ok(new CatalogInfoVm
            { 
                Products = products.ToList(), 
                ProductColors = productColors.ToList(), 
                ProductTypes = productTypes.ToList(), 
                ProductSizes = productSizes.ToList() 
            });
        }
    }
}
