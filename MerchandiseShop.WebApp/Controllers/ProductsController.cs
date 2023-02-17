using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers
{
    [Route("admin/products/{action=Index}/")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View("~/Views/Admin/Products/Index.cshtml");
        }
    }
}
