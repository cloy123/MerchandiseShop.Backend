using AutoMapper;
using MerchandiseShop.Application.ProductTypes.Commands.CreateProductType;
using MerchandiseShop.Application.ProductTypes.Commands.DeleteProductType;
using MerchandiseShop.Application.ProductTypes.Commands.UpdateProductType;
using MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeDetails;
using MerchandiseShop.Application.ProductTypes.Queries.GetProductTypeList;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers
{
    public class ProductTypesController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductTypesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetProductTypeListQuery();
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(ProductTypeDto productTypeDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateProductTypeCommand>(productTypeDto);
                var productTypeId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", productTypeDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetProductTypeDetailsQuery
            {
                Id = id.Value
            };
            var productTypeDetails = await Mediator.Send(query);
            if (productTypeDetails == null)
            {
                return NotFound();
            }

            var productTypeDto = _mapper.Map<ProductTypeDto>(productTypeDetails);

            return View("Delete", productTypeDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var command = new DeleteProductTypeCommand
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

            var query = new GetProductTypeDetailsQuery
            {
                Id = id.Value
            };
            var productTypeDetails = await Mediator.Send(query);
            var productTypeDto = _mapper.Map<ProductTypeDto>(productTypeDetails);

            return View("Edit", productTypeDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductTypeDto productTypeDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateProductTypeCommand>(productTypeDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", productTypeDto);
        }
    }
}
