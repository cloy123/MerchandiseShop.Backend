using AutoMapper;
using MerchandiseShop.Application.Users;
using MerchandiseShop.Application.Users.Queries.GetUserDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetUserInfo()
        {
            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var queryUser = new GetUserDetailsQuery() { Id = Guid.Parse(userIdClaim.Value) };
            var user = await Mediator.Send(queryUser);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(new {user});
        }

    }
}
