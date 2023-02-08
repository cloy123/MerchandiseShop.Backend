using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers.Admin
{
    [Route("admin/holidays/{action=Index}/")]
    public class AdminHolidaysController : BaseController
    {
        private readonly IMapper _mapper;

        public AdminHolidaysController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View("~/Views/Admin/Holidays/Index.cshtml");
        }
    }
}
