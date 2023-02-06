using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    [Route("auth")]
    public class AuthController: Controller
    {
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }
    }
}
