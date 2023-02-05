using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MerchandiseShop.IdentityService.Controllers
{
    [ApiController]
    [Route("identity/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
