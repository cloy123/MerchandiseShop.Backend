using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers.Admin
{
    [Route("admin/events/{action=Index}/")]
    public class AdminEventsController : BaseController
    {
        private readonly IMapper _mapper;

        public AdminEventsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View("~/Views/Admin/Events/Index.cshtml");
        }
    }
}
