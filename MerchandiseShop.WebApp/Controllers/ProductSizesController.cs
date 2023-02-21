using AutoMapper;
using MerchandiseShop.Application.ProductSizes.Commands.CreateProductSize;
using MerchandiseShop.Application.ProductSizes.Commands.DeleteProductSize;
using MerchandiseShop.Application.ProductSizes.Commands.UpdateProductSize;
using MerchandiseShop.Application.ProductSizes.Queries.GetProductSizeDetails;
using MerchandiseShop.Application.ProductSizes.Queries.GetProductSizeList;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers
{
    public class ProductSizesController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductSizesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetProductSizeListQuery();
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(ProductSizeDto productSizeDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateProductSizeCommand>(productSizeDto);
                var productSizeId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", productSizeDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetProductSizeDetailsQuery
            {
                Id = id.Value
            };
            var productSizeDetails = await Mediator.Send(query);
            if (productSizeDetails == null)
            {
                return NotFound();
            }

            var productSizeDto = _mapper.Map<ProductSizeDto>(productSizeDetails);

            return View("Delete", productSizeDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var command = new DeleteProductSizeCommand
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

            var query = new GetProductSizeDetailsQuery
            {
                Id = id.Value
            };
            var productSizeDetails = await Mediator.Send(query);
            var productSizeDto = _mapper.Map<ProductSizeDto>(productSizeDetails);

            return View("Edit", productSizeDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductSizeDto productSizeDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateProductSizeCommand>(productSizeDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", productSizeDto);
        }
    }
}
