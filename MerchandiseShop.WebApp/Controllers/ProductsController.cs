using AutoMapper;
using MerchandiseShop.Application.ProductColors.Queries.GetProductColorList;
using MerchandiseShop.Application.Products.Commands.CreateProduct;
using MerchandiseShop.Application.Products.Commands.DeleteProduct;
using MerchandiseShop.Application.Products.Commands.UpdateProduct;
using MerchandiseShop.Application.Products.Queries.GetProductDetails;
using MerchandiseShop.Application.Products.Queries.GetProductList;
using MerchandiseShop.Application.ProductSizes.Queries.GetProductSizeList;
using MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeList;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchandiseShop.WebApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public ProductsController(IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetProductListQuery();
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public async Task<IActionResult> Create()
        {
            var queryTypes = new GetProductTypeListQuery();
            var types = await Mediator.Send(queryTypes);

            var queryColors = new GetProductColorListQuery();
            var colors = await Mediator.Send(queryColors);

            var querySizes = new GetProductSizeListQuery();
            var sizes = await Mediator.Send(querySizes);

            ViewData["ProductSizeId"] = new SelectList(sizes.ProductSizes, "Id", "Name");
            ViewData["ProductColorId"] = new SelectList(colors.ProductColors, "Id", "Name");
            ViewData["ProductTypeId"] = new SelectList(types.ProductTypes, "Id", "Name");
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {

                var newFileName = System.IO.Path.GetRandomFileName() + System.IO.Path.GetExtension(productDto.ImageFile.FileName);
                productDto.ImageFileName = newFileName;
                var filePath = _appEnvironment.WebRootPath + "/images/" + newFileName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await productDto.ImageFile.CopyToAsync(stream);
                }
                var command = _mapper.Map<CreateProductCommand>(productDto);
                var productId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            var queryTypes = new GetProductTypeListQuery();
            var types = await Mediator.Send(queryTypes);

            var queryColors = new GetProductColorListQuery();
            var colors = await Mediator.Send(queryColors);

            var querySizes = new GetProductSizeListQuery();
            var sizes = await Mediator.Send(querySizes);

            ViewData["ProductSizeId"] = new SelectList(sizes.ProductSizes, "Id", "Name");
            ViewData["ProductColorId"] = new SelectList(colors.ProductColors, "Id", "Name");
            ViewData["ProductTypeId"] = new SelectList(types.ProductTypes, "Id", "Name");

            return View("Create", productDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetProductDetailsQuery
            {
                Id = id.Value
            };
            var productDetails = await Mediator.Send(query);
            if (productDetails == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(productDetails);

            return View("Delete", productDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };
            var product = await Mediator.Send(query);

            if (System.IO.File.Exists(_appEnvironment.WebRootPath + "/images/" + product.ImageFileName))
            {
                System.IO.File.Delete(_appEnvironment.WebRootPath + "/images/" + product.ImageFileName);
            }

            var command = new DeleteProductCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetProductDetailsQuery
            {
                Id = id.Value
            };
            var productDetails = await Mediator.Send(query);
            var updateProductDto = _mapper.Map<UpdateProductDto>(productDetails);

            var queryTypes = new GetProductTypeListQuery();
            var types = await Mediator.Send(queryTypes);

            var queryColors = new GetProductColorListQuery();
            var colors = await Mediator.Send(queryColors);

            var querySizes = new GetProductSizeListQuery();
            var sizes = await Mediator.Send(querySizes);

            ViewData["ProductSizeId"] = new SelectList(sizes.ProductSizes, "Id", "Name");
            ViewData["ProductColorId"] = new SelectList(colors.ProductColors, "Id", "Name");
            ViewData["ProductTypeId"] = new SelectList(types.ProductTypes, "Id", "Name");

            return View("Edit", updateProductDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductDto updateProductDto)
        {
            if (ModelState.IsValid)
            {
                if(updateProductDto.NewImageFile != null)
                {
                    if (System.IO.File.Exists(_appEnvironment.WebRootPath + "/images/" + updateProductDto.ImageFileName))
                    {
                        System.IO.File.Delete(_appEnvironment.WebRootPath + "/images/" + updateProductDto.ImageFileName);
                    }
                    var newFileName = System.IO.Path.GetRandomFileName() + System.IO.Path.GetExtension(updateProductDto.NewImageFile.FileName);
                    updateProductDto.ImageFileName = newFileName;
                    var filePath = _appEnvironment.WebRootPath + "/images/" + newFileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updateProductDto.NewImageFile.CopyToAsync(stream);
                    }
                }
                var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            var queryTypes = new GetProductTypeListQuery();
            var types = await Mediator.Send(queryTypes);

            var queryColors = new GetProductColorListQuery();
            var colors = await Mediator.Send(queryColors);

            var querySizes = new GetProductSizeListQuery();
            var sizes = await Mediator.Send(querySizes);

            ViewData["ProductSizeId"] = new SelectList(sizes.ProductSizes, "Id", "Name");
            ViewData["ProductColorId"] = new SelectList(colors.ProductColors, "Id", "Name");
            ViewData["ProductTypeId"] = new SelectList(types.ProductTypes, "Id", "Name");

            return View("Edit", updateProductDto);
        }
    }
}
