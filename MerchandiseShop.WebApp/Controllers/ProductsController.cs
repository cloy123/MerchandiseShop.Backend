using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
