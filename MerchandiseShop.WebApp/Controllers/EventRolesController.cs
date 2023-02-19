using AutoMapper;
using MerchandiseShop.Application.EventRoles.Commands.CreateEventRole;
using MerchandiseShop.Application.EventRoles.Commands.DeleteEventRole;
using MerchandiseShop.Application.EventRoles.Commands.UpdateEventRole;
using MerchandiseShop.Application.EventRoles.Queries.GetEventRoleDetails;
using MerchandiseShop.Application.EventRoles.Queries.GetEventRoleList;
using MerchandiseShop.Domain.Models;
using MerchandiseShop.Domain.Users;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchandiseShop.WebApp.Controllers
{
    public class EventRolesController : BaseController
    {
        private readonly IMapper _mapper;

        public EventRolesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(Guid eventId)
        {
            var query = new GetEventRoleListQuery()
            {
                EventId = eventId
            };
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public IActionResult Create(Guid eventId)
        {
            var vm = new EventRoleDto
            {
                EventId = eventId
            };

            var types = Enumeration.GetAll<UserType>().ToList();
            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");

            return View("Create", vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(EventRoleDto eventRoleDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateEventRoleCommand>(eventRoleDto);
                var eventRoleId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index), new { eventId = eventRoleDto.EventId });
            }

            var types = Enumeration.GetAll<UserType>().ToList();
            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");

            return View("Create", eventRoleDto);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetEventRoleDetailsQuery
            {
                Id = id.Value
            };
            var eventRoleDetails = await Mediator.Send(query);
            var eventRoleDto = _mapper.Map<EventRoleDto>(eventRoleDetails);

            var types = Enumeration.GetAll<UserType>().ToList();
            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");

            return View("Edit", eventRoleDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventRoleDto eventRoleDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateEventRoleCommand>(eventRoleDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index), new { eventId = eventRoleDto.EventId });
            }

            var types = Enumeration.GetAll<UserType>().ToList();
            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");

            return View("Edit", eventRoleDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetEventRoleDetailsQuery
            {
                Id = id.Value
            };
            var eventRoleDetails = await Mediator.Send(query);
            if (eventRoleDetails == null)
            {
                return NotFound();
            }

            var eventRoleDto = _mapper.Map<EventRoleDto>(eventRoleDetails);

            return View("Delete", eventRoleDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Guid eventId)
        {
            var command = new DeleteEventRoleCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index), new { eventId = eventId });
        }
    }
}
