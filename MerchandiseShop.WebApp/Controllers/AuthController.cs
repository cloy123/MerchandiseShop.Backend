using AutoMapper;
using MerchandiseShop.Application.Users.Commands.FindUser;
using MerchandiseShop.Domain.Models;
using MerchandiseShop.Domain.Users;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace MerchandiseShop.WebApp.Controllers
{
    public class AuthController: BaseController
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                
                return View(loginDto);
                
            }
            var command = _mapper.Map<FindUserCommand>(loginDto);
            var findUserVm = await Mediator.Send(command);
            if (findUserVm.IsUserFound && findUserVm.IsPasswordCorrect && 
                findUserVm.UserDto != null && 
                findUserVm.IsAccess &&
                (findUserVm.UserDto.UserTypeId == 0 || findUserVm.UserDto.UserTypeId == 1))
            {
                var role = Enumeration.GetAll<UserType>().FirstOrDefault(it => it.Id.Equals(findUserVm.UserDto.UserTypeId));
                if (role == null)
                {
                    throw new Exception();
                }
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.Email, findUserVm.UserDto.Email));
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                identity.AddClaim(new Claim("Id", findUserVm.UserDto.Id.ToString()));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    });
                return Redirect("/events/index");
            }
            return Redirect("/accessdenied");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/auth/login");
        }
    }
}
