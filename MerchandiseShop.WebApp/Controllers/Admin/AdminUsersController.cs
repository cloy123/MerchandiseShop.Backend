using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MerchandiseShop.Application.Users.Queries.GetUserList;
using MerchandiseShop.Application.Users.Queries.GetUserDetails;
using MerchandiseShop.Application.Users;
using MerchandiseShop.Domain.User;
using MerchandiseShop.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchandiseShop.WebApp.Controllers.Admin
{
    [Route("admin/users/{action=Index}/")]
    public class AdminUsersController : BaseController
    {
        private readonly IMapper _mapper;

        public AdminUsersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(UserListVm userListVm)
        {
            var query = new GetUserListQuery();
            var list = await Mediator.Send(query);
            return View("~/Views/Admin/Users/Index.cshtml", list);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetUserDetailsQuery
            {
                Id = id.Value
            };
            var userDetails = await Mediator.Send(query);
            var types = Enumeration.GetAll<UserType>().ToList();
            var genders = Enumeration.GetAll<UserGender>().ToList();
            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["UserGenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Users/Edit.cshtml", userDetails);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(UserDetailsVm userDetailsVm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        List<string> userTypes = new List<string>();

        //        var query = new GetUserDetailsQuery
        //        {
        //            Id = id.Value
        //        };
        //        var userDetails = await Mediator.Send(query);
        //        return View("~/Views/Admin/Users/Details.cshtml", userDetails);
        //    }


        //}

        //[HttpPost]
        //public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createHolidayDto)
        //{
        //    var command = _mapper.Map<CreateUserCommand>(createHolidayDto);
        //    var holidayId = await Mediator.Send(command);
        //    return Ok(holidayId);
        //}
    }
}
