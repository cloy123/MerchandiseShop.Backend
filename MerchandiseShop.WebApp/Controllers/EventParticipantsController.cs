using AutoMapper;
using MerchandiseShop.Application.EventParticipants.Commands.CreateEventParticipant;
using MerchandiseShop.Application.EventParticipants.Commands.DeleteEventParticipant;
using MerchandiseShop.Application.EventParticipants.Commands.UpdateEventParticipant;
using MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantDetails;
using MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantList;
using MerchandiseShop.Application.EventRoles.Queries.GetEventRoleList;
using MerchandiseShop.Application.Events.Queries.GetEventDetails;
using MerchandiseShop.Application.Users.Queries.GetUserList;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchandiseShop.WebApp.Controllers
{
    public class EventParticipantsController : BaseController
    {
        private readonly IMapper _mapper;

        public EventParticipantsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(Guid eventId)
        {
            var query = new GetEventParticipantListQuery()
            {
                EventId = eventId
            };
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public async Task<IActionResult> Create(Guid eventId)
        {
            var vm = new EventParticipantDto
            {
                EventId = eventId,
                IsVisit = false
            };

            var queryEvent = new GetEventDetailsQuery()
            {
                Id = eventId
            };
            var event_ = await Mediator.Send(queryEvent);
            var queryUsers = new GetUserListQuery();
            var list = await Mediator.Send(queryUsers);
            var users = list.Users.Where(u => event_.AvalibleFor.Contains(u.ClassNumber.ToString() + u.ClassLetter));

            var queryRoles = new GetEventRoleListQuery()
            {
                EventId = eventId
            };
            var roles = await Mediator.Send(queryRoles);

            ViewData["EventRoleId"] = new SelectList(roles.EventRoles, "Id", "Name");
            ViewData["UserId"] = new SelectList(users, "Id", "UserFullInfo");

            return View("Create", vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(EventParticipantDto eventParticipantDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateEventParticipantCommand>(eventParticipantDto);
                var eventParticipantId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index), new { eventId = eventParticipantDto.EventId });
            }

            var queryEvent = new GetEventDetailsQuery()
            {
                Id = eventParticipantDto.EventId
            };
            var event_ = await Mediator.Send(queryEvent);
            var queryUsers = new GetUserListQuery();
            var list = await Mediator.Send(queryUsers);
            var users = list.Users.Where(u => event_.AvalibleFor.Contains(u.ClassNumber.ToString() + u.ClassLetter));

            var queryRoles = new GetEventRoleListQuery()
            {
                EventId = eventParticipantDto.EventId
            };
            var roles = await Mediator.Send(queryRoles);

            ViewData["EventRoleId"] = new SelectList(roles.EventRoles, "Id", "Name");
            ViewData["UserId"] = new SelectList(users, "Id", "UserFullInfo");

            return View("Create", eventParticipantDto);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetEventParticipantDetailsQuery
            {
                Id = id.Value
            };
            var eventParticipantDetails = await Mediator.Send(query);
            var eventParticipantDto = _mapper.Map<EventParticipantDto>(eventParticipantDetails);

            var queryRoles = new GetEventRoleListQuery()
            {
                EventId = eventParticipantDto.EventId
            };
            var roles = await Mediator.Send(queryRoles);

            ViewData["EventRoleId"] = new SelectList(roles.EventRoles, "Id", "Name");

            return View("Edit", eventParticipantDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventParticipantDto eventParticipantDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateEventParticipantCommand>(eventParticipantDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index), new { eventId = eventParticipantDto.EventId });
            }

            var queryRoles = new GetEventRoleListQuery()
            {
                EventId = eventParticipantDto.EventId
            };
            var roles = await Mediator.Send(queryRoles);

            ViewData["EventRoleId"] = new SelectList(roles.EventRoles, "Id", "Name");

            return View("Edit", eventParticipantDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetEventParticipantDetailsQuery
            {
                Id = id.Value
            };
            var eventParticipantDetails = await Mediator.Send(query);
            if (eventParticipantDetails == null)
            {
                return NotFound();
            }

            var eventParticipantDto = _mapper.Map<EventParticipantDto>(eventParticipantDetails);

            return View("Delete", eventParticipantDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Guid eventId)
        {
            var command = new DeleteEventParticipantCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index), new { eventId = eventId });
        }
    }
}
