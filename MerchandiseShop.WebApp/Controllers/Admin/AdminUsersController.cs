using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MerchandiseShop.Application.Users.Queries.GetUserList;
using MerchandiseShop.Application.Users.Queries.GetUserDetails;
using MerchandiseShop.Application.Users;
using MerchandiseShop.Domain.User;
using MerchandiseShop.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MerchandiseShop.Application.Users.Commands.UpdateUser;
using MerchandiseShop.WebApp.Models;
using MerchandiseShop.Application.Users.Commands.CreateUser;
using MerchandiseShop.Application.Users.Commands.DeleteUserCommand;

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
            var userDto = _mapper.Map<UserDto>(userDetails);

            var types = Enumeration.GetAll<UserType>().ToList();
            types.Remove(UserType.All);
            var genders = Enumeration.GetAll<UserGender>().ToList();
            genders.Remove(UserGender.All);

            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["UserGenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Users/Edit.cshtml", userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateUserCommand>(userDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            var types = Enumeration.GetAll<UserType>().ToList();
            types.Remove(UserType.All);
            var genders = Enumeration.GetAll<UserGender>().ToList();
            genders.Remove(UserGender.All);

            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["UserGenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Users/Edit.cshtml", userDto);
        }

        public IActionResult Create()
        {
            var types = Enumeration.GetAll<UserType>().ToList();
            types.Remove(UserType.All);
            var genders = Enumeration.GetAll<UserGender>().ToList();
            genders.Remove(UserGender.All);

            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["UserGenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Users/Create.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateUserCommand>(userDto);
                var userId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            var types = Enumeration.GetAll<UserType>().ToList();
            types.Remove(UserType.All);
            var genders = Enumeration.GetAll<UserGender>().ToList();
            genders.Remove(UserGender.All);

            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["UserGenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Users/Create.cshtml", userDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
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
            if (userDetails == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(userDetails);

            return View("~/Views/Admin/Users/Delete.cshtml", userDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var command = new DeleteUserCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
