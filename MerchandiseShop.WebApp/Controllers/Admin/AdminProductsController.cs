using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers.Admin
{
    [Route("admin/products/{action=Index}/")]
    public class AdminProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public AdminProductsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View("~/Views/Admin/Products/Index.cshtml");
        }
    }
}
