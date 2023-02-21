using AutoMapper;
using MerchandiseShop.Application.ProductColors.Commands.CreateProductColor;
using MerchandiseShop.Application.ProductColors.Commands.DeleteProductColor;
using MerchandiseShop.Application.ProductColors.Commands.UpdateProductColor;
using MerchandiseShop.Application.ProductColors.Queries.GetProductColorDetails;
using MerchandiseShop.Application.ProductColors.Queries.GetProductColorList;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers
{
    public class ProductColorsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductColorsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetProductColorListQuery();
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(ProductColorDto productColorDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateProductColorCommand>(productColorDto);
                var productColorId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", productColorDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetProductColorDetailsQuery
            {
                Id = id.Value
            };
            var productColorDetails = await Mediator.Send(query);
            if (productColorDetails == null)
            {
                return NotFound();
            }

            var productColorDto = _mapper.Map<ProductColorDto>(productColorDetails);

            return View("Delete", productColorDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var command = new DeleteProductColorCommand
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

            var query = new GetProductColorDetailsQuery
            {
                Id = id.Value
            };
            var productColorDetails = await Mediator.Send(query);
            var productColorDto = _mapper.Map<ProductColorDto>(productColorDetails);

            return View("Edit", productColorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductColorDto productColorDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateProductColorCommand>(productColorDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", productColorDto);
        }
    }
}
